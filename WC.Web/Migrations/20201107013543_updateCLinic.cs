using Microsoft.EntityFrameworkCore.Migrations;

namespace WC.Web.Migrations
{
    public partial class updateCLinic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Clinic",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_CityId",
                table: "Clinic",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_Cities_CityId",
                table: "Clinic",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_Cities_CityId",
                table: "Clinic");

            migrationBuilder.DropIndex(
                name: "IX_Clinic_CityId",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Clinic");
        }
    }
}
