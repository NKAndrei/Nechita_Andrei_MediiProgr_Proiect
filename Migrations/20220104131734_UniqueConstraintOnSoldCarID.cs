using Microsoft.EntityFrameworkCore.Migrations;

namespace Nechita_Andrei_MediiProgr_Proiect.Migrations
{
    public partial class UniqueConstraintOnSoldCarID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldCar_Car_CarID",
                table: "SoldCar");

            migrationBuilder.DropIndex(
                name: "IX_SoldCar_CarID",
                table: "SoldCar");

            migrationBuilder.RenameColumn(
                name: "CarID",
                table: "SoldCar",
                newName: "CarId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldCar_Car_CarId",
                table: "SoldCar");

            migrationBuilder.DropIndex(
                name: "IX_SoldCar_CarId",
                table: "SoldCar");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "SoldCar",
                newName: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_SoldCar_CarID",
                table: "SoldCar",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldCar_Car_CarID",
                table: "SoldCar",
                column: "CarID",
                principalTable: "Car",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
