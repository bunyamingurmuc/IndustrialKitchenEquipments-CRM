using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialKitchenEquipmentsCRM.DAL.Migrations
{
    public partial class dsadasdsdsds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "CardItems");

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "CardItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
