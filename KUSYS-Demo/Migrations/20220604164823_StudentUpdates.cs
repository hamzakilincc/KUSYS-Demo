using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KUSYS_Demo.Migrations
{
    public partial class StudentUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMail",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");
        }
    }
}
