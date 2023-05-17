using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AltEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketProductEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProductEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetailEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetailEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBasketEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    ProductTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsOrdered = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBasketEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(24,4)", nullable: false),
                    BuilderCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategoryEntityId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductEntity_ProductCategoryEntity_ProductCategoryEntityId",
                        column: x => x.ProductCategoryEntityId,
                        principalSchema: "dbo",
                        principalTable: "ProductCategoryEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductEntityUserBasketEntity",
                schema: "dbo",
                columns: table => new
                {
                    ProductEntitiesId = table.Column<long>(type: "bigint", nullable: false),
                    UserBasketEntitiesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntityUserBasketEntity", x => new { x.ProductEntitiesId, x.UserBasketEntitiesId });
                    table.ForeignKey(
                        name: "FK_ProductEntityUserBasketEntity_ProductEntity_ProductEntitiesId",
                        column: x => x.ProductEntitiesId,
                        principalSchema: "dbo",
                        principalTable: "ProductEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductEntityUserBasketEntity_UserBasketEntity_UserBasketEntitiesId",
                        column: x => x.UserBasketEntitiesId,
                        principalSchema: "dbo",
                        principalTable: "UserBasketEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_ProductCategoryEntityId",
                schema: "dbo",
                table: "ProductEntity",
                column: "ProductCategoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntityUserBasketEntity_UserBasketEntitiesId",
                schema: "dbo",
                table: "ProductEntityUserBasketEntity",
                column: "UserBasketEntitiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AltEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BasketProductEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CustomerDetailEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ImageEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductEntityUserBasketEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TagEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserBasketEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductCategoryEntity",
                schema: "dbo");
        }
    }
}
