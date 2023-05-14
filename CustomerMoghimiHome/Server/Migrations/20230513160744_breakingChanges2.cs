using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class breakingChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<long>(
                name: "UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderEntity_UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity",
                column: "UserBasketId",
                unique: true,
                filter: "[UserBasketId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrderEntity_CustomerDetailEntity_UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity",
                column: "UserBasketId",
                principalSchema: "dbo",
                principalTable: "CustomerDetailEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrderEntity_UserBasketEntity_UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity",
                column: "UserBasketId",
                principalSchema: "dbo",
                principalTable: "UserBasketEntity",
                principalColumn: "Id");
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

            migrationBuilder.AlterColumn<long>(
                name: "UserBasketId",
                schema: "dbo",
                table: "UserOrderEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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
    }
}
