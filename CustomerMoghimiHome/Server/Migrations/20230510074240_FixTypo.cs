using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBasketEntity_UserOrderEntity_UserBasketId",
                schema: "dbo",
                table: "UserBasketEntity");

            migrationBuilder.RenameColumn(
                name: "UserBasketId",
                schema: "dbo",
                table: "UserBasketEntity",
                newName: "UserOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBasketEntity_UserBasketId",
                schema: "dbo",
                table: "UserBasketEntity",
                newName: "IX_UserBasketEntity_UserOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBasketEntity_UserOrderEntity_UserOrderId",
                schema: "dbo",
                table: "UserBasketEntity",
                column: "UserOrderId",
                principalSchema: "dbo",
                principalTable: "UserOrderEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBasketEntity_UserOrderEntity_UserOrderId",
                schema: "dbo",
                table: "UserBasketEntity");

            migrationBuilder.RenameColumn(
                name: "UserOrderId",
                schema: "dbo",
                table: "UserBasketEntity",
                newName: "UserBasketId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBasketEntity_UserOrderId",
                schema: "dbo",
                table: "UserBasketEntity",
                newName: "IX_UserBasketEntity_UserBasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBasketEntity_UserOrderEntity_UserBasketId",
                schema: "dbo",
                table: "UserBasketEntity",
                column: "UserBasketId",
                principalSchema: "dbo",
                principalTable: "UserOrderEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
