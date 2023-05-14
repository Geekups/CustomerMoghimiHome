using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixUserOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                schema: "dbo",
                table: "UserOrderEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                schema: "dbo",
                table: "UserOrderEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProductTotalPrice",
                schema: "dbo",
                table: "UserOrderEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCount",
                schema: "dbo",
                table: "UserOrderEntity");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "dbo",
                table: "UserOrderEntity");

            migrationBuilder.DropColumn(
                name: "ProductTotalPrice",
                schema: "dbo",
                table: "UserOrderEntity");
        }
    }
}
