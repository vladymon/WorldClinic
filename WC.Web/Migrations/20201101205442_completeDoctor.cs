using Microsoft.EntityFrameworkCore.Migrations;

namespace WC.Web.Migrations
{
    public partial class completeDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousCode",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Doctors",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Doctors",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Doctors",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "PreviousCode",
                table: "Doctors",
                maxLength: 20,
                nullable: true);
        }
    }
}
