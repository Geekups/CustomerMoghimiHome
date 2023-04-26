using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixCatProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntity_ProductCategoryEntity_ProductCategoryId",
                schema: "dbo",
                table: "ProductEntity");

            migrationBuilder.DropIndex(
                name: "IX_ProductEntity_ProductCategoryId",
                schema: "dbo",
                table: "ProductEntity");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                schema: "dbo",
                table: "ProductEntity");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_ProductCategoryEnityId",
                schema: "dbo",
                table: "ProductEntity",
                column: "ProductCategoryEnityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntity_ProductCategoryEntity_ProductCategoryEnityId",
                schema: "dbo",
                table: "ProductEntity",
                column: "ProductCategoryEnityId",
                principalSchema: "dbo",
                principalTable: "ProductCategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntity_ProductCategoryEntity_ProductCategoryEnityId",
                schema: "dbo",
                table: "ProductEntity");

            migrationBuilder.DropIndex(
                name: "IX_ProductEntity_ProductCategoryEnityId",
                schema: "dbo",
                table: "ProductEntity");

            migrationBuilder.AddColumn<long>(
                name: "ProductCategoryId",
                schema: "dbo",
                table: "ProductEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_ProductCategoryId",
                schema: "dbo",
                table: "ProductEntity",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntity_ProductCategoryEntity_ProductCategoryId",
                schema: "dbo",
                table: "ProductEntity",
                column: "ProductCategoryId",
                principalSchema: "dbo",
                principalTable: "ProductCategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
