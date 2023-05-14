using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class breakingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UserOrderId",
                schema: "dbo",
                table: "CustomerDetailEntity",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UserOrderId",
                schema: "dbo",
                table: "CustomerDetailEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
