using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavoriteLiterature.Works.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGenreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreWork_genres_GenresName",
                table: "GenreWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreWork",
                table: "GenreWork");

            migrationBuilder.DropPrimaryKey(
                name: "genres_pkey",
                table: "genres");

            migrationBuilder.DropColumn(
                name: "GenresName",
                table: "GenreWork");

            migrationBuilder.AddColumn<Guid>(
                name: "GenresId",
                table: "GenreWork",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "genres",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreWork",
                table: "GenreWork",
                columns: new[] { "GenresId", "WorksId" });

            migrationBuilder.AddPrimaryKey(
                name: "genres_pkey",
                table: "genres",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_genres_name",
                table: "genres",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreWork_genres_GenresId",
                table: "GenreWork",
                column: "GenresId",
                principalTable: "genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreWork_genres_GenresId",
                table: "GenreWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreWork",
                table: "GenreWork");

            migrationBuilder.DropPrimaryKey(
                name: "genres_pkey",
                table: "genres");

            migrationBuilder.DropIndex(
                name: "IX_genres_name",
                table: "genres");

            migrationBuilder.DropColumn(
                name: "GenresId",
                table: "GenreWork");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "genres");

            migrationBuilder.AddColumn<string>(
                name: "GenresName",
                table: "GenreWork",
                type: "character varying(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreWork",
                table: "GenreWork",
                columns: new[] { "GenresName", "WorksId" });

            migrationBuilder.AddPrimaryKey(
                name: "genres_pkey",
                table: "genres",
                column: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreWork_genres_GenresName",
                table: "GenreWork",
                column: "GenresName",
                principalTable: "genres",
                principalColumn: "name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
