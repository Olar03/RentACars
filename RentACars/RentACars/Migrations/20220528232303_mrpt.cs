using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACars.Migrations
{
    public partial class mrpt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemporalReserves");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Reserves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Reserves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Reserves");

            migrationBuilder.CreateTable(
                name: "TemporalReserves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporalReserves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemporalReserves_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TemporalReserves_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemporalReserves_UserId",
                table: "TemporalReserves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalReserves_VehicleId",
                table: "TemporalReserves",
                column: "VehicleId");
        }
    }
}
