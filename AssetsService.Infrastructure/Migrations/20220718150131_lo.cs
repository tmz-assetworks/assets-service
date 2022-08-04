using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetsService.Infrastructure.Migrations
{
    public partial class lo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetworkId",
                table: "Dispenser");

            migrationBuilder.DropColumn(
                name: "NetworkName",
                table: "Dispenser");

            migrationBuilder.DropColumn(
                name: "SubnetworkId",
                table: "Dispenser");

            migrationBuilder.DropColumn(
                name: "SubnetworkName",
                table: "Dispenser");

            migrationBuilder.AddColumn<string>(
                name: "FuelProtectType",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelProtectType",
                table: "Locations");

            migrationBuilder.AddColumn<long>(
                name: "NetworkId",
                table: "Dispenser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "NetworkName",
                table: "Dispenser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "SubnetworkId",
                table: "Dispenser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "SubnetworkName",
                table: "Dispenser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
