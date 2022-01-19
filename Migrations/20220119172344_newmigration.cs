using Microsoft.EntityFrameworkCore.Migrations;

namespace Nechita_Andrei_MediiProgr_Proiect.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldCar_Car_CarId",
                table: "SoldCar");

            migrationBuilder.DropIndex(
                name: "IX_SoldCar_CarId",
                table: "SoldCar");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "SoldCar");

            migrationBuilder.AddColumn<string>(
                name: "SoldCarDescription",
                table: "SoldCar",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "SoldCarPrice",
                table: "SoldCar",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SoldCarSerial",
                table: "SoldCar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SoldCar_SoldCarSerial",
                table: "SoldCar",
                column: "SoldCarSerial",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SoldCar_SoldCarSerial",
                table: "SoldCar");

            migrationBuilder.DropColumn(
                name: "SoldCarDescription",
                table: "SoldCar");

            migrationBuilder.DropColumn(
                name: "SoldCarPrice",
                table: "SoldCar");

            migrationBuilder.DropColumn(
                name: "SoldCarSerial",
                table: "SoldCar");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "SoldCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SoldCar_CarId",
                table: "SoldCar",
                column: "CarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldCar_Car_CarId",
                table: "SoldCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
