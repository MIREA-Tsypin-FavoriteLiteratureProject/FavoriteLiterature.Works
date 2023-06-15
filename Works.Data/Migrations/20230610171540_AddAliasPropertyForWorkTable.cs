using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavoriteLiterature.Works.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAliasPropertyForWorkTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "alias",
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
                name: "alias",
                table: "authors");
        }
    }
}
