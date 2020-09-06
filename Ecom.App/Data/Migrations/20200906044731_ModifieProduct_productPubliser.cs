using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecom.App.Data.Migrations
{
    public partial class ModifieProduct_productPubliser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_SKU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Edition",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsAproved",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsLimitedToStore",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsNewProduct",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsReturnAble",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsShippingChargeApplicable",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NotifyForMinimumQuantityBellow",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NumberOfPage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderMaximumQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderMinimumQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "countryId",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "CostPrice",
                table: "ProductPublishers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Edition",
                table: "ProductPublishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "ProductPublishers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAproved",
                table: "ProductPublishers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLimitedToStore",
                table: "ProductPublishers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewProduct",
                table: "ProductPublishers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "ProductPublishers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReturnAble",
                table: "ProductPublishers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShippingChargeApplicable",
                table: "ProductPublishers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NotifyForMinimumQuantityBellow",
                table: "ProductPublishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "NumberOfPage",
                table: "ProductPublishers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OldPrice",
                table: "ProductPublishers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "OrderMaximumQuantity",
                table: "ProductPublishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderMinimumQuantity",
                table: "ProductPublishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ProductPublishers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "ProductPublishers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "ProductPublishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countryId",
                table: "ProductPublishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPublishers_SKU",
                table: "ProductPublishers",
                column: "SKU",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductPublishers_SKU",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "Edition",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "IsAproved",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "IsLimitedToStore",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "IsNewProduct",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "IsReturnAble",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "IsShippingChargeApplicable",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "NotifyForMinimumQuantityBellow",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "NumberOfPage",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "OrderMaximumQuantity",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "OrderMinimumQuantity",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "ProductPublishers");

            migrationBuilder.DropColumn(
                name: "countryId",
                table: "ProductPublishers");

            migrationBuilder.AddColumn<double>(
                name: "CostPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Edition",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Products",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAproved",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLimitedToStore",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewProduct",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReturnAble",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShippingChargeApplicable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NotifyForMinimumQuantityBellow",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "NumberOfPage",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OldPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "OrderMaximumQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderMinimumQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Products",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SKU",
                table: "Products",
                column: "SKU",
                unique: true);
        }
    }
}
