using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebAPIProyectoDeGrado.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PuntoDeRecolecciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TipoDeMaterial = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Imagen = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoDeRecolecciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    Rol = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recicladores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Documento = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Telefono = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recicladores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recicladores_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Residentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Telefono = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Residentes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tiendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Telefono = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tiendas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Barrio = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    TiendaId = table.Column<int>(type: "integer", nullable: false),
                    PuntoDeRecoleccionId = table.Column<int>(type: "integer", nullable: false),
                    ResidenteId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Direcciones_PuntoDeRecolecciones_PuntoDeRecoleccionId",
                        column: x => x.PuntoDeRecoleccionId,
                        principalTable: "PuntoDeRecolecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Direcciones_Residentes_ResidenteId",
                        column: x => x.ResidenteId,
                        principalTable: "Residentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Direcciones_Tiendas_TiendaId",
                        column: x => x.TiendaId,
                        principalTable: "Tiendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_PuntoDeRecoleccionId",
                table: "Direcciones",
                column: "PuntoDeRecoleccionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_ResidenteId",
                table: "Direcciones",
                column: "ResidenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_TiendaId",
                table: "Direcciones",
                column: "TiendaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recicladores_UsuarioId",
                table: "Recicladores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Residentes_UsuarioId",
                table: "Residentes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tiendas_UsuarioId",
                table: "Tiendas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "Recicladores");

            migrationBuilder.DropTable(
                name: "PuntoDeRecolecciones");

            migrationBuilder.DropTable(
                name: "Residentes");

            migrationBuilder.DropTable(
                name: "Tiendas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
