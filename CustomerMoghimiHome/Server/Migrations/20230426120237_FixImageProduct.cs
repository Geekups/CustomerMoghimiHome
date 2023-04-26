using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixImageProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntity_ProductCategoryEntity_ProductCategoryEnityId",
                schema: "dbo",
                table: "ProductEntity");

            migrationBuilder.DropTable(
                name: "ImagesForProductEntity",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_ProductEntity_ProductCategoryEnityId",
                schema: "dbo",
                table: "ProductEntity");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                schema: "dbo",
                table: "ProductEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ProductCategoryId",
                schema: "dbo",
                table: "ProductEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                schema: "dbo",
                table: "ProductCategoryEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ImagePath",
                schema: "dbo",
                table: "ProductEntity");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                schema: "dbo",
                table: "ProductEntity");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                schema: "dbo",
                table: "ProductCategoryEntity");

            migrationBuilder.CreateTable(
                name: "ImagesForProductEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesForProductEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesForProductEntity_ImageEntity_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "dbo",
                        principalTable: "ImageEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImagesForProductEntity_ProductEntity_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "ProductEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_ProductCategoryEnityId",
                schema: "dbo",
                table: "ProductEntity",
                column: "ProductCategoryEnityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesForProductEntity_ImageId",
                schema: "dbo",
                table: "ImagesForProductEntity",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesForProductEntity_ProductId",
                schema: "dbo",
                table: "ImagesForProductEntity",
                column: "ProductId");

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
    }
}
