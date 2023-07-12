using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixDecimalBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "dbo",
                table: "ProductEntity",
                type: "decimal(24,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(24,4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "dbo",
                table: "ProductEntity",
                type: "decimal(24,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(24,0)");
        }
    }
}
