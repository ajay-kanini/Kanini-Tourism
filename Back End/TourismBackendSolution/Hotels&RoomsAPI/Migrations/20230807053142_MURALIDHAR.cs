using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotels_RoomsAPI.Migrations
{
    public partial class MURALIDHAR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRooms",
                table: "Rooms");

            migrationBuilder.AddColumn<DateTime>(
                name: "checkInDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "checkOutDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "checkInDate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "checkOutDate",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRooms",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
