using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBazaar.Migrations
{
    public partial class ChangesToCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_sellers_SellerId",
                table: "cars");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_sellers_SellerId",
                table: "cars",
                column: "SellerId",
                principalTable: "sellers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_sellers_SellerId",
                table: "cars");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_sellers_SellerId",
                table: "cars",
                column: "SellerId",
                principalTable: "sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
