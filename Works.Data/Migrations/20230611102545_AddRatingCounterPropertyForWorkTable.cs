using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavoriteLiterature.Works.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingCounterPropertyForWorkTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rating_counter",
                table: "works",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rating_counter",
                table: "works");
        }
    }
}
