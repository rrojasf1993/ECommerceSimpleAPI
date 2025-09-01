using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.TechnicalTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4383), "Description for product 1", "Product", 7m, 101, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4474) },
                    { 2, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4568), "Description for product 2", "Product", 8m, 102, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4568) },
                    { 3, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4571), "Description for product 3", "Product", 9m, 103, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4571) },
                    { 4, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4573), "Description for product 4", "Product", 10m, 104, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4573) },
                    { 5, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4575), "Description for product 5", "Product", 11m, 105, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4575) },
                    { 6, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4582), "Description for product 6", "Product", 12m, 106, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4582) },
                    { 7, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4626), "Description for product 7", "Product", 13m, 107, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4627) },
                    { 8, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4628), "Description for product 8", "Product", 14m, 108, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4628) },
                    { 9, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4630), "Description for product 9", "Product", 15m, 109, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4635) },
                    { 10, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4638), "Description for product 10", "Product", 16m, 110, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4639) },
                    { 11, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4640), "Description for product 11", "Product", 17m, 111, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4640) },
                    { 12, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4641), "Description for product 12", "Product", 18m, 112, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4641) },
                    { 13, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4643), "Description for product 13", "Product", 19m, 113, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4643) },
                    { 14, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4644), "Description for product 14", "Product", 20m, 114, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4644) },
                    { 15, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4645), "Description for product 15", "Product", 21m, 115, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4646) },
                    { 16, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4647), "Description for product 16", "Product", 22m, 116, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4647) },
                    { 17, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4648), "Description for product 17", "Product", 23m, 117, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4648) },
                    { 18, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4650), "Description for product 18", "Product", 24m, 118, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4650) },
                    { 19, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4660), "Description for product 19", "Product", 25m, 119, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4660) },
                    { 20, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4662), "Description for product 20", "Product", 26m, 120, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4662) },
                    { 21, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4663), "Description for product 21", "Product", 27m, 121, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4663) },
                    { 22, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4664), "Description for product 22", "Product", 28m, 122, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4665) },
                    { 23, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4666), "Description for product 23", "Product", 29m, 123, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4666) },
                    { 24, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4667), "Description for product 24", "Product", 30m, 124, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4667) },
                    { 25, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4671), "Description for product 25", "Product", 31m, 125, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4671) },
                    { 26, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4677), "Description for product 26", "Product", 32m, 126, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4677) },
                    { 27, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4679), "Description for product 27", "Product", 33m, 127, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4679) },
                    { 28, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4680), "Description for product 28", "Product", 34m, 128, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4680) },
                    { 29, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4681), "Description for product 29", "Product", 35m, 129, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4682) },
                    { 30, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4684), "Description for product 30", "Product", 36m, 130, new DateTime(2025, 8, 29, 8, 1, 47, 41, DateTimeKind.Utc).AddTicks(4684) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "C##ECOMMERCE",
                table: "PRODUCTS",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
