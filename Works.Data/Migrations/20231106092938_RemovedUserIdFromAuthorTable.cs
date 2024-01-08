using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavoriteLiterature.Works.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserIdFromAuthorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_authors_user_id",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "authors");

            migrationBuilder.RenameColumn(
                name: "alias",
                table: "authors",
                newName: "nick_name");

            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "authors",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "full_name",
                table: "authors");

            migrationBuilder.RenameColumn(
                name: "nick_name",
                table: "authors",
                newName: "alias");

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "authors",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_authors_user_id",
                table: "authors",
                column: "user_id",
                unique: true);
        }
    }
}
