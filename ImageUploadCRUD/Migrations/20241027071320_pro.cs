using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageUploadCRUD.Migrations
{
    /// <inheritdoc />
    public partial class pro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProNmae",
                table: "ProductsImg",
                newName: "ProName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProName",
                table: "ProductsImg",
                newName: "ProNmae");
        }
    }
}
