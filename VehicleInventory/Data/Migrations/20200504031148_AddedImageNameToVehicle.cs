using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleInventory.Data.Migrations
{
    public partial class AddedImageNameToVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Vehicles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Vehicles");
        }
    }
}
