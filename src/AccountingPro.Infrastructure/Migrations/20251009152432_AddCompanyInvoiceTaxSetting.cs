using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyInvoiceTaxSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnableInvoiceTax",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2518));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EnableInvoiceTax" },
                values: new object[] { new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2296), true });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2623));

            migrationBuilder.UpdateData(
                table: "FiscalYears",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2661));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2724));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnableInvoiceTax",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4670));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4677));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4683));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "FiscalYears",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 5, 38, 52, 594, DateTimeKind.Utc).AddTicks(4885));
        }
    }
}
