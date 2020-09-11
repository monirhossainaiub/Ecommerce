using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecom.App.Data.Migrations
{
    public partial class AddProduct_Writer_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_WriterId",
                table: "Products",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Writers_WriterId",
                table: "Products",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Writers_WriterId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_WriterId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Products");
        }
    }
}
