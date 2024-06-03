using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C03_HeThongTimGiupViec.Migrations
{
    public partial class Attribute1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Complaints",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "ResponeComplaintId",
                table: "Complaints",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponeComplaintId",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Complaints",
                newName: "status");
        }
    }
}
