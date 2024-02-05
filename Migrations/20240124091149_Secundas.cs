using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergsBilar_RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class Secundas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Customers",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Customers",
                newName: "password");
        }
    }
}
