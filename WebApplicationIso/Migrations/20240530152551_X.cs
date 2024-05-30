using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationIso.Migrations
{
    /// <inheritdoc />
    public partial class X : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PurchasedProducts_PurchasedProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedProducts_Customers_CustomerId",
                table: "PurchasedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedProducts_Sales_SaleId",
                table: "PurchasedProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedProducts",
                table: "PurchasedProducts");

            migrationBuilder.DropIndex(
                name: "IX_PurchasedProducts_SaleId",
                table: "PurchasedProducts");

            migrationBuilder.DropColumn(
                name: "Expire",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "PurchasedProducts");

            migrationBuilder.RenameTable(
                name: "PurchasedProducts",
                newName: "PurchasedProduct");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Sales",
                newName: "TotalSalePrice");

            migrationBuilder.RenameColumn(
                name: "DateOfSale",
                table: "Sales",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sales",
                newName: "SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedProducts_CustomerId",
                table: "PurchasedProduct",
                newName: "IX_PurchasedProduct_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedProduct",
                table: "PurchasedProduct",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SaleProducts",
                columns: table => new
                {
                    SaleProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProducts", x => x.SaleProductId);
                    table.ForeignKey(
                        name: "FK_SaleProducts_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleProducts_SaleId",
                table: "SaleProducts",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PurchasedProduct_PurchasedProductId",
                table: "Products",
                column: "PurchasedProductId",
                principalTable: "PurchasedProduct",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedProduct_Customers_CustomerId",
                table: "PurchasedProduct",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PurchasedProduct_PurchasedProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedProduct_Customers_CustomerId",
                table: "PurchasedProduct");

            migrationBuilder.DropTable(
                name: "SaleProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedProduct",
                table: "PurchasedProduct");

            migrationBuilder.RenameTable(
                name: "PurchasedProduct",
                newName: "PurchasedProducts");

            migrationBuilder.RenameColumn(
                name: "TotalSalePrice",
                table: "Sales",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Sales",
                newName: "DateOfSale");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "Sales",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedProduct_CustomerId",
                table: "PurchasedProducts",
                newName: "IX_PurchasedProducts_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "Expire",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "PurchasedProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedProducts",
                table: "PurchasedProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedProducts_SaleId",
                table: "PurchasedProducts",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PurchasedProducts_PurchasedProductId",
                table: "Products",
                column: "PurchasedProductId",
                principalTable: "PurchasedProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedProducts_Customers_CustomerId",
                table: "PurchasedProducts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedProducts_Sales_SaleId",
                table: "PurchasedProducts",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id");
        }
    }
}
