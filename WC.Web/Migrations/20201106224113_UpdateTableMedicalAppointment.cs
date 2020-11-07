using Microsoft.EntityFrameworkCore.Migrations;

namespace WC.Web.Migrations
{
    public partial class UpdateTableMedicalAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_AspNetUsers_UserId",
                table: "MedicalAppointments");

            migrationBuilder.DropIndex(
                name: "IX_MedicalAppointments_UserId",
                table: "MedicalAppointments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MedicalAppointments");

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "MedicalAppointments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "MedicalAppointments");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MedicalAppointments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointments_UserId",
                table: "MedicalAppointments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_AspNetUsers_UserId",
                table: "MedicalAppointments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
