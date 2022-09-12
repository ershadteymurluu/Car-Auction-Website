using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBazaar.Migrations
{
    public partial class ChangesAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "cars",
                newName: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_cars_YearId",
                table: "cars",
                column: "YearId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_years_YearId",
                table: "cars",
                column: "YearId",
                principalTable: "years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_years_YearId",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_YearId",
                table: "cars");

            migrationBuilder.RenameColumn(
                name: "YearId",
                table: "cars",
                newName: "Year");
        }
    }
}
