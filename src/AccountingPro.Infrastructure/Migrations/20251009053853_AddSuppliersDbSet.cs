using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSuppliersDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Companies_CompanyId1",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Supplier_SupplierId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_CompanyId1",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Invoices_InvoiceId",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Products_ProductId",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Companies_CompanyId1",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Companies_CompanyId1",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Supplier_SupplierId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Companies_CompanyId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Companies_CompanyId1",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Tax_Companies_CompanyId1",
                table: "Tax");

            migrationBuilder.DropIndex(
                name: "IX_Tax_CompanyId1",
                table: "Tax");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CompanyId1",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CompanyId1",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyId1",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Bills_CompanyId1",
                table: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_CompanyId1",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceItem",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Tax");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Supplier");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "InvoiceItem",
                newName: "InvoiceItems");

            migrationBuilder.RenameIndex(
                name: "IX_Supplier_CompanyId_Name",
                table: "Suppliers",
                newName: "IX_Suppliers_CompanyId_Name");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItem_ProductId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItem_InvoiceId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceItems",
                table: "InvoiceItems",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Suppliers_SupplierId",
                table: "Bills",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Products_ProductId",
                table: "InvoiceItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Suppliers_SupplierId",
                table: "Payment",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Companies_CompanyId",
                table: "Suppliers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Suppliers_SupplierId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Products_ProductId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Suppliers_SupplierId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Companies_CompanyId",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceItems",
                table: "InvoiceItems");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "InvoiceItems",
                newName: "InvoiceItem");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_CompanyId_Name",
                table: "Supplier",
                newName: "IX_Supplier_CompanyId_Name");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_ProductId",
                table: "InvoiceItem",
                newName: "IX_InvoiceItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItem",
                newName: "IX_InvoiceItem_InvoiceId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Tax",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Payment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceItem",
                table: "InvoiceItem",
                column: "Id");

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
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyId1", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7139) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompanyId1", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7144) });

            migrationBuilder.UpdateData(
                table: "FiscalYears",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyId1", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7173) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompanyId1", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompanyId1", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyId1", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 8, 16, 26, 2, 105, DateTimeKind.Utc).AddTicks(7206) });

            migrationBuilder.CreateIndex(
                name: "IX_Tax_CompanyId1",
                table: "Tax",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId1",
                table: "Products",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CompanyId1",
                table: "Payment",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CompanyId1",
                table: "Invoices",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId1",
                table: "Customers",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CompanyId1",
                table: "Bills",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CompanyId1",
                table: "Supplier",
                column: "CompanyId1");

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
                name: "FK_Customers_Companies_CompanyId1",
                table: "Customers",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Invoices_InvoiceId",
                table: "InvoiceItem",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Products_ProductId",
                table: "InvoiceItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Companies_CompanyId1",
                table: "Invoices",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Companies_CompanyId1",
                table: "Payment",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Supplier_SupplierId",
                table: "Payment",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tax_Companies_CompanyId1",
                table: "Tax",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
