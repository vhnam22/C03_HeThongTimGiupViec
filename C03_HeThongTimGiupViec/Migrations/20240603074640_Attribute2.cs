using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C03_HeThongTimGiupViec.Migrations
{
    public partial class Attribute2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResponeComplaintId",
                table: "Complaints",
                newName: "ResponseComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ResponseComplaintId",
                table: "Complaints",
                column: "ResponseComplaintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaint_ResponseComplaint",
                table: "Complaints",
                column: "ResponseComplaintId",
                principalTable: "Complaints",
                principalColumn: "ComplaintID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaint_ResponseComplaint",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ResponseComplaintId",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "ResponseComplaintId",
                table: "Complaints",
                newName: "ResponeComplaintId");
        }
    }
}
