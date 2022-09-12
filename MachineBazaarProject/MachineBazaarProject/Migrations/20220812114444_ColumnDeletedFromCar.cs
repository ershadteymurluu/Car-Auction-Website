using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBazaar.Migrations
{
    public partial class ColumnDeletedFromCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_AspNetUsers_AppUserId1",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_AppUserId1",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "cars");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "cars",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_cars_AppUserId",
                table: "cars",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_AspNetUsers_AppUserId",
                table: "cars",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_AspNetUsers_AppUserId",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_AppUserId",
                table: "cars");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "cars",
                type: "nvarchar(450)",
                nullable: true);

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
    }
}
