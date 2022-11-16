using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialKitchenEquipmentsCRM.DAL.Migrations
{
    public partial class saddasdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockDescription",
                table: "Stocks",
                newName: "StockDescription2");

            migrationBuilder.AddColumn<string>(
                name: "StockDescription1",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockDescription1",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "StockDescription2",
                table: "Stocks",
                newName: "StockDescription");
        }
    }
}
