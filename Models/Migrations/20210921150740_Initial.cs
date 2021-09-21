using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PG.Models.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    password = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    state = table.Column<bool>(type: "boolean", nullable: false),
                    role = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recycler",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    last_name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    document_type = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    document = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recycler", x => x.id);
                    table.ForeignKey(
                        name: "FK_recycler_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "resident",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    last_name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resident", x => x.id);
                    table.ForeignKey(
                        name: "FK_resident_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shop",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    document_type = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    document = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop", x => x.id);
                    table.ForeignKey(
                        name: "FK_shop_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "route",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CommentId = table.Column<int>(type: "integer", nullable: true),
                    RecyclerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route", x => x.id);
                    table.ForeignKey(
                        name: "FK_route_comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "comment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_route_recycler_RecyclerId",
                        column: x => x.RecyclerId,
                        principalTable: "recycler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "collection_point",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    type_of_material = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    image = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    description = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    state = table.Column<bool>(type: "boolean", nullable: false),
                    RouteId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collection_point", x => x.id);
                    table.ForeignKey(
                        name: "FK_collection_point_route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "route",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "adress",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    neighborhood = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    street_type = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    career = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    number_one = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    number_two = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    description = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    ResidentId = table.Column<int>(type: "integer", nullable: true),
                    shop_id = table.Column<int>(type: "integer", nullable: true),
                    collection_point_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adress", x => x.id);
                    table.ForeignKey(
                        name: "FK_adress_collection_point_collection_point_id",
                        column: x => x.collection_point_id,
                        principalTable: "collection_point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_adress_resident_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "resident",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_adress_shop_shop_id",
                        column: x => x.shop_id,
                        principalTable: "shop",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adress_collection_point_id",
                table: "adress",
                column: "collection_point_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_adress_ResidentId",
                table: "adress",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_adress_shop_id",
                table: "adress",
                column: "shop_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_collection_point_RouteId",
                table: "collection_point",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_recycler_UserId",
                table: "recycler",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_resident_UserId",
                table: "resident",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_route_CommentId",
                table: "route",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_route_RecyclerId",
                table: "route",
                column: "RecyclerId");

            migrationBuilder.CreateIndex(
                name: "IX_shop_UserId",
                table: "shop",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adress");

            migrationBuilder.DropTable(
                name: "collection_point");

            migrationBuilder.DropTable(
                name: "resident");

            migrationBuilder.DropTable(
                name: "shop");

            migrationBuilder.DropTable(
                name: "route");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "recycler");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
