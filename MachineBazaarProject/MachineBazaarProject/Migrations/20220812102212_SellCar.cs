using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBazaar.Migrations
{
    public partial class SellCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "cars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerNote",
                table: "cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_cars_AppUserId1",
                table: "cars",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_AspNetUsers_AppUserId1",
                table: "cars",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_AspNetUsers_AppUserId1",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_AppUserId1",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "SellerNote",
                table: "cars");
        }
    }
}
