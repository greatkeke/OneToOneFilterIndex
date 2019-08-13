using Microsoft.EntityFrameworkCore.Migrations;

namespace demo1.Migrations
{
    public partial class FilterIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Notes_ItemId",
                table: "Notes");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ItemId",
                table: "Notes",
                column: "ItemId",
                unique: true,
                filter: "[Deleted]=0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Notes_ItemId",
                table: "Notes");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ItemId",
                table: "Notes",
                column: "ItemId",
                unique: true);
        }
    }
}
