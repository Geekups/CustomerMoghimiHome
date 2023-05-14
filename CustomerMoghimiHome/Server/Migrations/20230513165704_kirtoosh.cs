using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class kirtoosh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOrderEntity_CustomerDetailEntity_UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity");

            migrationBuilder.DropColumn(
                name: "UserOrderId",
                schema: "dbo",
                table: "CustomerDetailEntity");

            migrationBuilder.AddColumn<long>(
                name: "CustomerDetailEntityId",
                schema: "dbo",
                table: "UserOrderEntity",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderEntity_CustomerDetailEntityId",
                schema: "dbo",
                table: "UserOrderEntity",
                column: "CustomerDetailEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrderEntity_CustomerDetailEntity_CustomerDetailEntityId",
                schema: "dbo",
                table: "UserOrderEntity",
                column: "CustomerDetailEntityId",
                principalSchema: "dbo",
                principalTable: "CustomerDetailEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOrderEntity_CustomerDetailEntity_CustomerDetailEntityId",
                schema: "dbo",
                table: "UserOrderEntity");

            migrationBuilder.DropIndex(
                name: "IX_UserOrderEntity_CustomerDetailEntityId",
                schema: "dbo",
                table: "UserOrderEntity");

            migrationBuilder.DropColumn(
                name: "CustomerDetailEntityId",
                schema: "dbo",
                table: "UserOrderEntity");

            migrationBuilder.AddColumn<long>(
                name: "UserOrderId",
                schema: "dbo",
                table: "CustomerDetailEntity",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrderEntity_CustomerDetailEntity_UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity",
                column: "UserBasketId",
                principalSchema: "dbo",
                principalTable: "CustomerDetailEntity",
                principalColumn: "Id");
        }
    }
}
