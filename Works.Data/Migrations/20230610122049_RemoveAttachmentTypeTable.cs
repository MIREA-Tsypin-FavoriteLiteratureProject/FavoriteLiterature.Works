using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavoriteLiterature.Works.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAttachmentTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attachments_attachment_types_attachment_types_id",
                table: "attachments");

            migrationBuilder.DropTable(
                name: "attachment_types");

            migrationBuilder.DropIndex(
                name: "IX_attachments_attachment_types_id",
                table: "attachments");

            migrationBuilder.AlterColumn<string>(
                name: "attachment_types_id",
                table: "attachments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "attachment_types_id",
                table: "attachments",
                type: "character varying(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

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

            migrationBuilder.CreateIndex(
                name: "IX_attachments_attachment_types_id",
                table: "attachments",
                column: "attachment_types_id");

            migrationBuilder.AddForeignKey(
                name: "FK_attachments_attachment_types_attachment_types_id",
                table: "attachments",
                column: "attachment_types_id",
                principalTable: "attachment_types",
                principalColumn: "name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
