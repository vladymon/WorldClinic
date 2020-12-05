using Microsoft.EntityFrameworkCore.Migrations;

namespace WC.Web.Migrations
{
    public partial class ClinicController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_Cities_CityId",
                table: "Clinic");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_Clinic_ClinicId",
                table: "MedicalAppointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinic",
                table: "Clinic");

            migrationBuilder.RenameTable(
                name: "Clinic",
                newName: "Clinics");

            migrationBuilder.RenameIndex(
                name: "IX_Clinic_CityId",
                table: "Clinics",
                newName: "IX_Clinics_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Cities_CityId",
                table: "Clinics",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_Clinics_ClinicId",
                table: "MedicalAppointments",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Cities_CityId",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_Clinics_ClinicId",
                table: "MedicalAppointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics");

            migrationBuilder.RenameTable(
                name: "Clinics",
                newName: "Clinic");

            migrationBuilder.RenameIndex(
                name: "IX_Clinics_CityId",
                table: "Clinic",
                newName: "IX_Clinic_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinic",
                table: "Clinic",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_Cities_CityId",
                table: "Clinic",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_Clinic_ClinicId",
                table: "MedicalAppointments",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
