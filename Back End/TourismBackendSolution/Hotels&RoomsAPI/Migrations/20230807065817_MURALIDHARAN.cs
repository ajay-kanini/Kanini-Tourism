using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotels_RoomsAPI.Migrations
{
    public partial class MURALIDHARAN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "roomAvailability",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "roomAvailability",
                table: "Rooms");
        }
    }
}
