using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBazaar.Migrations
{
    public partial class SellerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
