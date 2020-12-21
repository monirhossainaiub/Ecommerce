using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecom.App.Data.Migrations
{
    public partial class addIsGoSlider_atributet_To_ProductEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShippingChargeApplicable",
                table: "ProductPublishers");

            migrationBuilder.AddColumn<bool>(
                name: "IsGoSlider",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGoSlider",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsShippingChargeApplicable",
                table: "ProductPublishers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
