using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shelter.Migrations
{
    /// <inheritdoc />
    public partial class AddressChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Addres",
                table: "PetShelters",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Addres",
                table: "Owners",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "PetShelters",
                newName: "Addres");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Owners",
                newName: "Addres");
        }
    }
}
