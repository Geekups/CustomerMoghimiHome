using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixUserOrder2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                schema: "dbo",
                table: "UserOrderEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                schema: "dbo",
                table: "UserOrderEntity");
        }
    }
}
