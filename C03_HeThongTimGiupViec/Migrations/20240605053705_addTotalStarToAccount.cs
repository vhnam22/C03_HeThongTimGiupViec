using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C03_HeThongTimGiupViec.Migrations
{
    public partial class addTotalStarToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalStar",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalStar",
                table: "AspNetUsers");
        }
    }
}
