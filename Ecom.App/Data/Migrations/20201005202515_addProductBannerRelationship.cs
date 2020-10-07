using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecom.App.Data.Migrations
{
    public partial class addProductBannerRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BannerId",
                table: "ProductPublishers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPublishers_BannerId",
                table: "ProductPublishers",
                column: "BannerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPublishers_Banners_BannerId",
                table: "ProductPublishers",
                column: "BannerId",
                principalTable: "Banners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPublishers_Banners_BannerId",
                table: "ProductPublishers");

            migrationBuilder.DropIndex(
                name: "IX_ProductPublishers_BannerId",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "BannerId",
                table: "ProductPublishers");
        }
    }
}
