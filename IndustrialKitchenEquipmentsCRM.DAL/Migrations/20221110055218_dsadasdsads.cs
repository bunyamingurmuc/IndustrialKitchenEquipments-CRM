using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialKitchenEquipmentsCRM.DAL.Migrations
{
    public partial class dsadasdsads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardItems_Cards_CardId",
                table: "CardItems");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "CardItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CardItems_Cards_CardId",
                table: "CardItems",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardItems_Cards_CardId",
                table: "CardItems");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "CardItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CardItems_Cards_CardId",
                table: "CardItems",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
