using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecom.App.Data.Migrations
{
    public partial class addProduct_ProductNote_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductNotes_ProductId",
                table: "ProductNotes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductNotes_Products_ProductId",
                table: "ProductNotes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductNotes_Products_ProductId",
                table: "ProductNotes");

            migrationBuilder.DropIndex(
                name: "IX_ProductNotes_ProductId",
                table: "ProductNotes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductNotes");
        }
    }
}
