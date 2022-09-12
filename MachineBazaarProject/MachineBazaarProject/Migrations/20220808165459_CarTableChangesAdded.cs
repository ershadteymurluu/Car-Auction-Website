using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBazaar.Migrations
{
    public partial class CarTableChangesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyStyle",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "cars");

            migrationBuilder.AlterColumn<double>(
                name: "MotorSize",
                table: "cars",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BodyStyleId",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuelTypeId",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransmissionId",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "fuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fuelTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_BodyStyleId",
                table: "cars",
                column: "BodyStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_cars_FuelTypeId",
                table: "cars",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_cars_TransmissionId",
                table: "cars",
                column: "TransmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_bodyStyles_BodyStyleId",
                table: "cars",
                column: "BodyStyleId",
                principalTable: "bodyStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_fuelTypes_FuelTypeId",
                table: "cars",
                column: "FuelTypeId",
                principalTable: "fuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_transmissions_TransmissionId",
                table: "cars",
                column: "TransmissionId",
                principalTable: "transmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_bodyStyles_BodyStyleId",
                table: "cars");

            migrationBuilder.DropForeignKey(
                name: "FK_cars_fuelTypes_FuelTypeId",
                table: "cars");

            migrationBuilder.DropForeignKey(
                name: "FK_cars_transmissions_TransmissionId",
                table: "cars");

            migrationBuilder.DropTable(
                name: "fuelTypes");

            migrationBuilder.DropIndex(
                name: "IX_cars_BodyStyleId",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_FuelTypeId",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_TransmissionId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "BodyStyleId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "FuelTypeId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "cars");

            migrationBuilder.AlterColumn<string>(
                name: "MotorSize",
                table: "cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "BodyStyle",
                table: "cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
