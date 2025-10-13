using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProformaInvoiceFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProformaInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProformaNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Terms = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ConvertedToInvoiceId = table.Column<int>(type: "int", nullable: true),
                    ConvertedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProformaInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProformaInvoices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProformaInvoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProformaInvoices_Invoices_ConvertedToInvoiceId",
                        column: x => x.ConvertedToInvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProformaInvoiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProformaInvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProformaInvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProformaInvoiceItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProformaInvoiceItems_ProformaInvoices_ProformaInvoiceId",
                        column: x => x.ProformaInvoiceId,
                        principalTable: "ProformaInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7787));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7791));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "FiscalYears",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7854));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7921));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 13, 16, 38, 27, 405, DateTimeKind.Utc).AddTicks(7973));

            migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoiceItems_ProductId",
                table: "ProformaInvoiceItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoiceItems_ProformaInvoiceId",
                table: "ProformaInvoiceItems",
                column: "ProformaInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoices_CompanyId_ProformaNumber",
                table: "ProformaInvoices",
                columns: new[] { "CompanyId", "ProformaNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoices_ConvertedToInvoiceId",
                table: "ProformaInvoices",
                column: "ConvertedToInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoices_CustomerId",
                table: "ProformaInvoices",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProformaInvoiceItems");

            migrationBuilder.DropTable(
                name: "ProformaInvoices");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3628));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3633));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3638));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3643));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "FiscalYears",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3837));
        }
    }
}
