using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierId = table.Column<long>(type: "bigint", nullable: false),
                    FreightPayerId = table.Column<long>(type: "bigint", nullable: false),
                    BookingType = table.Column<int>(type: "int", nullable: false),
                    BookingStatus = table.Column<int>(type: "int", nullable: false),
                    OrderRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DispatchMemo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Cubic = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    WeightActual = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CubicActual = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CartageCharge = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    SurchargeCharge = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TotalCharge = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CurrentVehicleId = table.Column<long>(type: "bigint", nullable: true),
                    LastVehicleId = table.Column<long>(type: "bigint", nullable: true),
                    ContainerDemurrageDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ContainerDetentionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ContainerDischargedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    ContainerJobType = table.Column<int>(type: "int", nullable: true),
                    ContainerPortCode = table.Column<int>(type: "int", nullable: true),
                    ContainerNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerVesselName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerVoyageNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerReleaseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerPinNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Organization_Carrier",
                        column: x => x.CarrierId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Booking_Organization_FreightPayer",
                        column: x => x.FreightPayerId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Booking_Vehicle_CurrentVehicle",
                        column: x => x.CurrentVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Booking_Vehicle_LastVehicle",
                        column: x => x.LastVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarrierId",
                table: "Bookings",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CreatedByUserId",
                table: "Bookings",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CurrentVehicleId",
                table: "Bookings",
                column: "CurrentVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FreightPayerId",
                table: "Bookings",
                column: "FreightPayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_LastVehicleId",
                table: "Bookings",
                column: "LastVehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
