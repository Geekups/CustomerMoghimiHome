using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations.Data
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
                    BasketId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProductEntity", x => new { x.BasketId, x.ProductId });
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
                name: "UserOrderEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrderEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBasketEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerDetailId = table.Column<long>(type: "bigint", nullable: false),
                    UserBasketId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBasketEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBasketEntity_CustomerDetailEntity_CustomerDetailId",
                        column: x => x.CustomerDetailId,
                        principalSchema: "dbo",
                        principalTable: "CustomerDetailEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBasketEntity_UserOrderEntity_UserBasketId",
                        column: x => x.UserBasketId,
                        principalSchema: "dbo",
                        principalTable: "UserOrderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ProductEntityId = table.Column<long>(type: "bigint", nullable: true),
                    UserBasketEntityId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_ProductEntity_ProductEntity_ProductEntityId",
                        column: x => x.ProductEntityId,
                        principalSchema: "dbo",
                        principalTable: "ProductEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductEntity_UserBasketEntity_UserBasketEntityId",
                        column: x => x.UserBasketEntityId,
                        principalSchema: "dbo",
                        principalTable: "UserBasketEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_ProductCategoryEntityId",
                schema: "dbo",
                table: "ProductEntity",
                column: "ProductCategoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_ProductEntityId",
                schema: "dbo",
                table: "ProductEntity",
                column: "ProductEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_UserBasketEntityId",
                schema: "dbo",
                table: "ProductEntity",
                column: "UserBasketEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBasketEntity_CustomerDetailId",
                schema: "dbo",
                table: "UserBasketEntity",
                column: "CustomerDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBasketEntity_UserBasketId",
                schema: "dbo",
                table: "UserBasketEntity",
                column: "UserBasketId",
                unique: true);
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
                name: "ImageEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TagEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductCategoryEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserBasketEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CustomerDetailEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserOrderEntity",
                schema: "dbo");
        }
    }
}
