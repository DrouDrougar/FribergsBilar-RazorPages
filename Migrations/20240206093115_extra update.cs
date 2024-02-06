using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergsBilar_RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class extraupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OldOrders_CarId",
                table: "OldOrders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_OldOrders_CustomerId",
                table: "OldOrders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OldOrders_Cars_CarId",
                table: "OldOrders",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OldOrders_Customers_CustomerId",
                table: "OldOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OldOrders_Cars_CarId",
                table: "OldOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_OldOrders_Customers_CustomerId",
                table: "OldOrders");

            migrationBuilder.DropIndex(
                name: "IX_OldOrders_CarId",
                table: "OldOrders");

            migrationBuilder.DropIndex(
                name: "IX_OldOrders_CustomerId",
                table: "OldOrders");
        }
    }
}
