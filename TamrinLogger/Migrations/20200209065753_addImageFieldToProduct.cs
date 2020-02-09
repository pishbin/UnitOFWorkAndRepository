using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TamrinLogger.Migrations
{
    public partial class addImageFieldToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Products",
                type: "image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");
        }
    }
}
