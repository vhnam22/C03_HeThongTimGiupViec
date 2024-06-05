using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C03_HeThongTimGiupViec.Migrations
{
    public partial class Attribute3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__Accounts__A9D10534B6EC2145",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Accounts__A9D10534B6EC2145",
                table: "AspNetUsers",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__Accounts__A9D10534B6EC2145",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.CreateIndex(
                name: "UQ__Accounts__A9D10534B6EC2145",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }
    }
}
