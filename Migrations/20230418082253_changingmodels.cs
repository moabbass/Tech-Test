using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verto.Migrations
{
    public partial class changingmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "picture",
                table: "SpecialOffer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "picture",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "buttonName",
                table: "Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "picture",
                table: "Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "picture",
                table: "SpecialOffer");

            migrationBuilder.DropColumn(
                name: "picture",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "buttonName",
                table: "Detail");

            migrationBuilder.DropColumn(
                name: "picture",
                table: "Detail");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Product",
                newName: "Name");
        }
    }
}
