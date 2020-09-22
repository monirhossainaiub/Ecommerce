using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecom.App.Data.Migrations
{
    public partial class addIdToProductPublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPublishers",
                table: "ProductPublishers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductPublishers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPublishers",
                table: "ProductPublishers",
                columns: new[] { "ProductId", "PublisherId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPublishers",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductPublishers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPublishers",
                table: "ProductPublishers",
                columns: new[] { "ProductId", "PublisherId" });
        }
    }
}
