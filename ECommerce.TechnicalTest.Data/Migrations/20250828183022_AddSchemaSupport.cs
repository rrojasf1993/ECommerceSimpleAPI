using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.TechnicalTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSchemaSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemDetails_Orders_OrderId",
                table: "OrderItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemDetails_Products_ProductId",
                table: "OrderItemDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemDetails",
                table: "OrderItemDetails");

            migrationBuilder.EnsureSchema(
                name: "C##ECOMMERCE");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "PRODUCTS",
                newSchema: "C##ECOMMERCE");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "ORDERS",
                newSchema: "C##ECOMMERCE");

            migrationBuilder.RenameTable(
                name: "OrderItemDetails",
                newName: "ORDER_ITEM_DETAILS",
                newSchema: "C##ECOMMERCE");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemDetails_ProductId",
                schema: "C##ECOMMERCE",
                table: "ORDER_ITEM_DETAILS",
                newName: "IX_ORDER_ITEM_DETAILS_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemDetails_OrderId",
                schema: "C##ECOMMERCE",
                table: "ORDER_ITEM_DETAILS",
                newName: "IX_ORDER_ITEM_DETAILS_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCTS",
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ORDERS",
                schema: "C##ECOMMERCE",
                table: "ORDERS",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ORDER_ITEM_DETAILS",
                schema: "C##ECOMMERCE",
                table: "ORDER_ITEM_DETAILS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_ITEM_DETAILS_ORDERS_OrderId",
                schema: "C##ECOMMERCE",
                table: "ORDER_ITEM_DETAILS",
                column: "OrderId",
                principalSchema: "C##ECOMMERCE",
                principalTable: "ORDERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_ITEM_DETAILS_PRODUCTS_ProductId",
                schema: "C##ECOMMERCE",
                table: "ORDER_ITEM_DETAILS",
                column: "ProductId",
                principalSchema: "C##ECOMMERCE",
                principalTable: "PRODUCTS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_ITEM_DETAILS_ORDERS_OrderId",
                schema: "C##ECOMMERCE",
                table: "ORDER_ITEM_DETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_ITEM_DETAILS_PRODUCTS_ProductId",
                schema: "C##ECOMMERCE",
                table: "ORDER_ITEM_DETAILS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCTS",
                schema: "C##ECOMMERCE",
                table: "PRODUCTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ORDERS",
                schema: "C##ECOMMERCE",
                table: "ORDERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ORDER_ITEM_DETAILS",
                schema: "C##ECOMMERCE",
                table: "ORDER_ITEM_DETAILS");

            migrationBuilder.RenameTable(
                name: "PRODUCTS",
                schema: "C##ECOMMERCE",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ORDERS",
                schema: "C##ECOMMERCE",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "ORDER_ITEM_DETAILS",
                schema: "C##ECOMMERCE",
                newName: "OrderItemDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ORDER_ITEM_DETAILS_ProductId",
                table: "OrderItemDetails",
                newName: "IX_OrderItemDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ORDER_ITEM_DETAILS_OrderId",
                table: "OrderItemDetails",
                newName: "IX_OrderItemDetails_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemDetails",
                table: "OrderItemDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemDetails_Orders_OrderId",
                table: "OrderItemDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemDetails_Products_ProductId",
                table: "OrderItemDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
