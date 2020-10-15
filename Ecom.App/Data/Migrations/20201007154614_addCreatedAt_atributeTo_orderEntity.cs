using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecom.App.Data.Migrations
{
    public partial class addCreatedAt_atributeTo_orderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Orders");
        }
    }
}
