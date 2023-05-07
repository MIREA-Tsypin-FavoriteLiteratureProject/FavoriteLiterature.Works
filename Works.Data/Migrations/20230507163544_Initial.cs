using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavoriteLiterature.Works.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attachment_types",
                columns: table => new
                {
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("attachment_types_pkey", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    public_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("authors_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("genres_pkey", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "works",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rating = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("works_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "attachments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    works_id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_id = table.Column<Guid>(type: "uuid", nullable: false),
                    attachment_types_id = table.Column<string>(type: "character varying(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("attachments_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_attachments_attachment_types_attachment_types_id",
                        column: x => x.attachment_types_id,
                        principalTable: "attachment_types",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attachments_works_works_id",
                        column: x => x.works_id,
                        principalTable: "works",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorWork",
                columns: table => new
                {
                    AuthorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorWork", x => new { x.AuthorsId, x.WorksId });
                    table.ForeignKey(
                        name: "FK_AuthorWork_authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorWork_works_WorksId",
                        column: x => x.WorksId,
                        principalTable: "works",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreWork",
                columns: table => new
                {
                    GenresName = table.Column<string>(type: "character varying(50)", nullable: false),
                    WorksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreWork", x => new { x.GenresName, x.WorksId });
                    table.ForeignKey(
                        name: "FK_GenreWork_genres_GenresName",
                        column: x => x.GenresName,
                        principalTable: "genres",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreWork_works_WorksId",
                        column: x => x.WorksId,
                        principalTable: "works",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attachments_attachment_types_id",
                table: "attachments",
                column: "attachment_types_id");

            migrationBuilder.CreateIndex(
                name: "IX_attachments_works_id",
                table: "attachments",
                column: "works_id");

            migrationBuilder.CreateIndex(
                name: "IX_authors_user_id",
                table: "authors",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorWork_WorksId",
                table: "AuthorWork",
                column: "WorksId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreWork_WorksId",
                table: "GenreWork",
                column: "WorksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attachments");

            migrationBuilder.DropTable(
                name: "AuthorWork");

            migrationBuilder.DropTable(
                name: "GenreWork");

            migrationBuilder.DropTable(
                name: "attachment_types");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "works");
        }
    }
}
