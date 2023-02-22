using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameLibrary.Migrations
{
    public partial class AddUIDToGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Games");
        }
    }
}
