using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecom.App.Data.Migrations
{
    public partial class add_ProductPublisher_Comment_Rating_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductPublisherId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductPublisherId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProductPublisherId",
                table: "Ratings",
                column: "ProductPublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductPublisherId",
                table: "Comments",
                column: "ProductPublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ProductPublishers_ProductPublisherId",
                table: "Comments",
                column: "ProductPublisherId",
                principalTable: "ProductPublishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_ProductPublishers_ProductPublisherId",
                table: "Ratings",
                column: "ProductPublisherId",
                principalTable: "ProductPublishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ProductPublishers_ProductPublisherId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_ProductPublishers_ProductPublisherId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_ProductPublisherId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProductPublisherId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProductPublisherId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "ProductPublisherId",
                table: "Comments");
        }
    }
}
