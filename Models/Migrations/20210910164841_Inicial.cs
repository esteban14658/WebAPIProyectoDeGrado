using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PG.Models.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollectionPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TypeOfMaterial = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Image = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    Description = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    State = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    State = table.Column<bool>(type: "boolean", nullable: false),
                    Role = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recyclers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    DocumentType = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Document = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recyclers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recyclers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Residents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    DocumentType = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Document = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Neighborhood = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    StreetType = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Career = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    NumberOne = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    NumberTwo = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    ShopId = table.Column<int>(type: "integer", nullable: true),
                    CollectionPointId = table.Column<int>(type: "integer", nullable: true),
                    ResidentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_CollectionPoints_CollectionPointId",
                        column: x => x.CollectionPointId,
                        principalTable: "CollectionPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CollectionPointId",
                table: "Addresses",
                column: "CollectionPointId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ResidentId",
                table: "Addresses",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ShopId",
                table: "Addresses",
                column: "ShopId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recyclers_UserId",
                table: "Recyclers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_UserId",
                table: "Residents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_UserId",
                table: "Shops",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Recyclers");

            migrationBuilder.DropTable(
                name: "CollectionPoints");

            migrationBuilder.DropTable(
                name: "Residents");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
