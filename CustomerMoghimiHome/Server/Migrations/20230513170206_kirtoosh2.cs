using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class kirtoosh2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
