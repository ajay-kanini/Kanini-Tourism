using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingAPI.Migrations
{
    public partial class MURALIDHA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Bookings",
                newName: "CheckOut");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Bookings",
                newName: "CheckIn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckOut",
                table: "Bookings",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "CheckIn",
                table: "Bookings",
                newName: "EndDate");
        }
    }
}
