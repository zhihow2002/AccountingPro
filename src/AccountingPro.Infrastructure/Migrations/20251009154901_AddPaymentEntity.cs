using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Accounts_BankAccountId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Bills_BillId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Companies_CompanyId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Customers_CustomerId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Invoices_InvoiceId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Suppliers_SupplierId",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_SupplierId",
                table: "Payments",
                newName: "IX_Payments_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_InvoiceId",
                table: "Payments",
                newName: "IX_Payments_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_CustomerId",
                table: "Payments",
                newName: "IX_Payments_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_CompanyId_PaymentNumber",
                table: "Payments",
                newName: "IX_Payments_CompanyId_PaymentNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_BillId",
                table: "Payments",
                newName: "IX_Payments_BillId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_BankAccountId",
                table: "Payments",
                newName: "IX_Payments_BankAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4492));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "FiscalYears",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4619));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 49, 1, 180, DateTimeKind.Utc).AddTicks(4680));

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Accounts_BankAccountId",
                table: "Payments",
                column: "BankAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bills_BillId",
                table: "Payments",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Companies_CompanyId",
                table: "Payments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                table: "Payments",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Suppliers_SupplierId",
                table: "Payments",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Accounts_BankAccountId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bills_BillId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Companies_CompanyId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Suppliers_SupplierId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_SupplierId",
                table: "Payment",
                newName: "IX_Payment_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payment",
                newName: "IX_Payment_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_CustomerId",
                table: "Payment",
                newName: "IX_Payment_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_CompanyId_PaymentNumber",
                table: "Payment",
                newName: "IX_Payment_CompanyId_PaymentNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_BillId",
                table: "Payment",
                newName: "IX_Payment_BillId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_BankAccountId",
                table: "Payment",
                newName: "IX_Payment_BankAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");

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
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 15, 24, 31, 290, DateTimeKind.Utc).AddTicks(2296));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Accounts_BankAccountId",
                table: "Payment",
                column: "BankAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Bills_BillId",
                table: "Payment",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Companies_CompanyId",
                table: "Payment",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Customers_CustomerId",
                table: "Payment",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Invoices_InvoiceId",
                table: "Payment",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Suppliers_SupplierId",
                table: "Payment",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}
