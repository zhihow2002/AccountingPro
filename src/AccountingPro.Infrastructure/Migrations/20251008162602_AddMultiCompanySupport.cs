using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountingPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMultiCompanySupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Supplier_SupplierId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_BillItem_Bill_BillId",
                table: "BillItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BillItem_Product_ProductId",
                table: "BillItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Product_ProductId",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Bill_BillId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Accounts_ExpenseAccountId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Accounts_IncomeAccountId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bill",
                table: "Bill");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Bill",
                newName: "Bills");

            migrationBuilder.RenameIndex(
                name: "IX_Product_IncomeAccountId",
                table: "Products",
                newName: "IX_Products_IncomeAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ExpenseAccountId",
                table: "Products",
                newName: "IX_Products_ExpenseAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_SupplierId",
                table: "Bills",
                newName: "IX_Bills_SupplierId");

            migrationBuilder.AlterColumn<string>(
                name: "TaxNumber",
                table: "Supplier",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Supplier",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Supplier",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Supplier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Supplier",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentNumber",
                table: "Payment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Payment",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                table: "Invoices",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxRate",
                table: "InvoiceItem",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "InvoiceItem",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InvoiceItem",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxRate",
                table: "BillItem",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "BillItem",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BillItem",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillNumber",
                table: "Bills",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bills",
                table: "Bills",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TaxAccountId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tax_Accounts_TaxAccountId",
                        column: x => x.TaxAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tax_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tax_Companies_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(6841));

            migrationBuilder.UpdateData(
                table: "FiscalYears",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate" },
                values: new object[] { new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7109), new DateTime(2024, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified) });

            migrationBuilder.Sql("UPDATE Customers SET CompanyId = 1 WHERE CompanyId = 0");
            migrationBuilder.Sql("UPDATE Products SET CompanyId = 1 WHERE CompanyId = 0");
            migrationBuilder.Sql("UPDATE Supplier SET CompanyId = 1 WHERE CompanyId = 0");
            migrationBuilder.Sql("UPDATE Invoices SET CompanyId = 1 WHERE CompanyId = 0");
            migrationBuilder.Sql("UPDATE Bills SET CompanyId = 1 WHERE CompanyId = 0");
            migrationBuilder.Sql("UPDATE Payment SET CompanyId = 1 WHERE CompanyId = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CompanyId_Name",
                table: "Supplier",
                columns: new[] { "CompanyId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CompanyId1",
                table: "Supplier",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CompanyId_PaymentNumber",
                table: "Payment",
                columns: new[] { "CompanyId", "PaymentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CompanyId1",
                table: "Payment",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CompanyId_InvoiceNumber",
                table: "Invoices",
                columns: new[] { "CompanyId", "InvoiceNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CompanyId1",
                table: "Invoices",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId_Name",
                table: "Customers",
                columns: new[] { "CompanyId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId1",
                table: "Customers",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId_SKU",
                table: "Products",
                columns: new[] { "CompanyId", "SKU" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId1",
                table: "Products",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CompanyId_BillNumber",
                table: "Bills",
                columns: new[] { "CompanyId", "BillNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CompanyId1",
                table: "Bills",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tax_CompanyId_Name",
                table: "Tax",
                columns: new[] { "CompanyId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tax_CompanyId1",
                table: "Tax",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tax_TaxAccountId",
                table: "Tax",
                column: "TaxAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillItem_Bills_BillId",
                table: "BillItem",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillItem_Products_ProductId",
                table: "BillItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Companies_CompanyId",
                table: "Bills",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Companies_CompanyId1",
                table: "Bills",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Supplier_SupplierId",
                table: "Bills",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Companies_CompanyId1",
                table: "Customers",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Products_ProductId",
                table: "InvoiceItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Companies_CompanyId",
                table: "Invoices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Companies_CompanyId1",
                table: "Invoices",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Payment_Companies_CompanyId1",
                table: "Payment",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Accounts_ExpenseAccountId",
                table: "Products",
                column: "ExpenseAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Accounts_IncomeAccountId",
                table: "Products",
                column: "IncomeAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId1",
                table: "Products",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Companies_CompanyId",
                table: "Supplier",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Companies_CompanyId1",
                table: "Supplier",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillItem_Bills_BillId",
                table: "BillItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BillItem_Products_ProductId",
                table: "BillItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Companies_CompanyId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Companies_CompanyId1",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Supplier_SupplierId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_CompanyId1",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Products_ProductId",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Companies_CompanyId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Companies_CompanyId1",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Bills_BillId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Companies_CompanyId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Companies_CompanyId1",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Accounts_ExpenseAccountId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Accounts_IncomeAccountId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Companies_CompanyId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Companies_CompanyId1",
                table: "Supplier");

            migrationBuilder.DropTable(
                name: "Tax");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_CompanyId_Name",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_CompanyId1",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CompanyId_PaymentNumber",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CompanyId1",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CompanyId_InvoiceNumber",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CompanyId1",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyId_Name",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyId1",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId_SKU",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId1",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bills",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_CompanyId_BillNumber",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_CompanyId1",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Bills");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Bills",
                newName: "Bill");

            migrationBuilder.RenameIndex(
                name: "IX_Products_IncomeAccountId",
                table: "Product",
                newName: "IX_Product_IncomeAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ExpenseAccountId",
                table: "Product",
                newName: "IX_Product_ExpenseAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_SupplierId",
                table: "Bill",
                newName: "IX_Bill_SupplierId");

            migrationBuilder.AlterColumn<string>(
                name: "TaxNumber",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentNumber",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxRate",
                table: "InvoiceItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "InvoiceItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InvoiceItem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxRate",
                table: "BillItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "BillItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BillItem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "BillNumber",
                table: "Bill",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bill",
                table: "Bill",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 15, 6, 48, 257, DateTimeKind.Utc).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 15, 6, 48, 257, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 15, 6, 48, 257, DateTimeKind.Utc).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 15, 6, 48, 257, DateTimeKind.Utc).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 15, 6, 48, 257, DateTimeKind.Utc).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 15, 6, 48, 257, DateTimeKind.Utc).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 15, 6, 48, 257, DateTimeKind.Utc).AddTicks(7087));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 15, 6, 48, 257, DateTimeKind.Utc).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 15, 6, 48, 257, DateTimeKind.Utc).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 15, 6, 48, 257, DateTimeKind.Utc).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 15, 6, 48, 257, DateTimeKind.Utc).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "FiscalYears",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate" },
                values: new object[] { new DateTime(2025, 10, 8, 15, 6, 48, 257, DateTimeKind.Utc).AddTicks(7148), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Supplier_SupplierId",
                table: "Bill",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillItem_Bill_BillId",
                table: "BillItem",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillItem_Product_ProductId",
                table: "BillItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Product_ProductId",
                table: "InvoiceItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Bill_BillId",
                table: "Payment",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Accounts_ExpenseAccountId",
                table: "Product",
                column: "ExpenseAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Accounts_IncomeAccountId",
                table: "Product",
                column: "IncomeAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
