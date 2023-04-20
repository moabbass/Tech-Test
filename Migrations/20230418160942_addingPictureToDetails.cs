using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verto.Migrations
{
    public partial class addingPictureToDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "picture",
                table: "Detail",
                newName: "pictureName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pictureName",
                table: "Detail",
                newName: "picture");
        }
    }
}
