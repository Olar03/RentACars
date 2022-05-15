using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACars.Migrations
{
    public partial class DBADVANC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemporalReserve_AspNetUsers_UserId",
                table: "TemporalReserve");

            migrationBuilder.DropForeignKey(
                name: "FK_TemporalReserve_Reserve_ReserveId",
                table: "TemporalReserve");

            migrationBuilder.DropForeignKey(
                name: "FK_TemporalReserve_Vehicles_VehicleId",
                table: "TemporalReserve");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemporalReserve",
                table: "TemporalReserve");

            migrationBuilder.RenameTable(
                name: "TemporalReserve",
                newName: "TemporalReserves");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "Vehicles",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_TemporalReserve_VehicleId",
                table: "TemporalReserves",
                newName: "IX_TemporalReserves_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_TemporalReserve_UserId",
                table: "TemporalReserves",
                newName: "IX_TemporalReserves_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TemporalReserve_ReserveId",
                table: "TemporalReserves",
                newName: "IX_TemporalReserves_ReserveId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemporalReserves",
                table: "TemporalReserves",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalReserves_Id",
                table: "TemporalReserves",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TemporalReserves_AspNetUsers_UserId",
                table: "TemporalReserves",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TemporalReserves_Reserve_ReserveId",
                table: "TemporalReserves",
                column: "ReserveId",
                principalTable: "Reserve",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TemporalReserves_Vehicles_VehicleId",
                table: "TemporalReserves",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemporalReserves_AspNetUsers_UserId",
                table: "TemporalReserves");

            migrationBuilder.DropForeignKey(
                name: "FK_TemporalReserves_Reserve_ReserveId",
                table: "TemporalReserves");

            migrationBuilder.DropForeignKey(
                name: "FK_TemporalReserves_Vehicles_VehicleId",
                table: "TemporalReserves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemporalReserves",
                table: "TemporalReserves");

            migrationBuilder.DropIndex(
                name: "IX_TemporalReserves_Id",
                table: "TemporalReserves");

            migrationBuilder.RenameTable(
                name: "TemporalReserves",
                newName: "TemporalReserve");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Vehicles",
                newName: "Remarks");

            migrationBuilder.RenameIndex(
                name: "IX_TemporalReserves_VehicleId",
                table: "TemporalReserve",
                newName: "IX_TemporalReserve_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_TemporalReserves_UserId",
                table: "TemporalReserve",
                newName: "IX_TemporalReserve_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TemporalReserves_ReserveId",
                table: "TemporalReserve",
                newName: "IX_TemporalReserve_ReserveId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemporalReserve",
                table: "TemporalReserve",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TemporalReserve_AspNetUsers_UserId",
                table: "TemporalReserve",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TemporalReserve_Reserve_ReserveId",
                table: "TemporalReserve",
                column: "ReserveId",
                principalTable: "Reserve",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TemporalReserve_Vehicles_VehicleId",
                table: "TemporalReserve",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
