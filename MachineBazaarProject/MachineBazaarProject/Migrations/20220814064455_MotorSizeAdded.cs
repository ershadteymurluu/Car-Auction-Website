using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBazaar.Migrations
{
    public partial class MotorSizeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_sellers_SellerId",
                table: "cars");

            migrationBuilder.DropTable(
                name: "sellers");

            migrationBuilder.DropIndex(
                name: "IX_cars_SellerId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "cars");

            migrationBuilder.RenameColumn(
                name: "MotorSize",
                table: "cars",
                newName: "MotorSizeId");

            migrationBuilder.CreateTable(
                name: "motorSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motorSizes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_MotorSizeId",
                table: "cars",
                column: "MotorSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_motorSizes_MotorSizeId",
                table: "cars",
                column: "MotorSizeId",
                principalTable: "motorSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_motorSizes_MotorSizeId",
                table: "cars");

            migrationBuilder.DropTable(
                name: "motorSizes");

            migrationBuilder.DropIndex(
                name: "IX_cars_MotorSizeId",
                table: "cars");

            migrationBuilder.RenameColumn(
                name: "MotorSizeId",
                table: "cars",
                newName: "MotorSize");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sellers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_SellerId",
                table: "cars",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_sellers_SellerId",
                table: "cars",
                column: "SellerId",
                principalTable: "sellers",
                principalColumn: "Id");
        }
    }
}
