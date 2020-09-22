using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecom.App.Data.Migrations
{
    public partial class ModifyProductPublisher_Photo_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Products_ProductId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Photos",
                newName: "ProductPublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_ProductId",
                table: "Photos",
                newName: "IX_Photos_ProductPublisherId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProductPublishers_Id",
                table: "ProductPublishers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_ProductPublishers_ProductPublisherId",
                table: "Photos",
                column: "ProductPublisherId",
                principalTable: "ProductPublishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_ProductPublishers_ProductPublisherId",
                table: "Photos");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProductPublishers_Id",
                table: "ProductPublishers");

            migrationBuilder.RenameColumn(
                name: "ProductPublisherId",
                table: "Photos",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_ProductPublisherId",
                table: "Photos",
                newName: "IX_Photos_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Products_ProductId",
                table: "Photos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
