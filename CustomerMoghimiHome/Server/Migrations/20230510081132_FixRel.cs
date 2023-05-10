using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBasketEntity_CustomerDetailEntity_CustomerDetailId",
                schema: "dbo",
                table: "UserBasketEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBasketEntity_UserOrderEntity_UserOrderId",
                schema: "dbo",
                table: "UserBasketEntity");

            migrationBuilder.DropIndex(
                name: "IX_UserBasketEntity_CustomerDetailId",
                schema: "dbo",
                table: "UserBasketEntity");

            migrationBuilder.DropIndex(
                name: "IX_UserBasketEntity_UserOrderId",
                schema: "dbo",
                table: "UserBasketEntity");

            migrationBuilder.DropColumn(
                name: "CustomerDetailId",
                schema: "dbo",
                table: "UserBasketEntity");

            migrationBuilder.DropColumn(
                name: "UserOrderId",
                schema: "dbo",
                table: "UserBasketEntity");

            migrationBuilder.AddColumn<long>(
                name: "UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserOrderId",
                schema: "dbo",
                table: "CustomerDetailEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderEntity_UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity",
                column: "UserBasketId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrderEntity_CustomerDetailEntity_UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity",
                column: "UserBasketId",
                principalSchema: "dbo",
                principalTable: "CustomerDetailEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrderEntity_UserBasketEntity_UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity",
                column: "UserBasketId",
                principalSchema: "dbo",
                principalTable: "UserBasketEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOrderEntity_CustomerDetailEntity_UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrderEntity_UserBasketEntity_UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity");

            migrationBuilder.DropIndex(
                name: "IX_UserOrderEntity_UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity");

            migrationBuilder.DropColumn(
                name: "UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity");

            migrationBuilder.DropColumn(
                name: "UserOrderId",
                schema: "dbo",
                table: "CustomerDetailEntity");

            migrationBuilder.AddColumn<long>(
                name: "CustomerDetailId",
                schema: "dbo",
                table: "UserBasketEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserOrderId",
                schema: "dbo",
                table: "UserBasketEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UserBasketEntity_CustomerDetailId",
                schema: "dbo",
                table: "UserBasketEntity",
                column: "CustomerDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBasketEntity_UserOrderId",
                schema: "dbo",
                table: "UserBasketEntity",
                column: "UserOrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBasketEntity_CustomerDetailEntity_CustomerDetailId",
                schema: "dbo",
                table: "UserBasketEntity",
                column: "CustomerDetailId",
                principalSchema: "dbo",
                principalTable: "CustomerDetailEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
