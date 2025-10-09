using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountingPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCountryMasterWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NumericCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Code3", "CreatedAt", "CreatedBy", "Currency", "CurrencySymbol", "IsActive", "IsDeleted", "Name", "NumericCode", "PhoneCode", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "AF", "AFG", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "AFN", "؋", true, false, "Afghanistan", "004", "+93", null, null },
                    { 2, "AL", "ALB", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "ALL", "L", true, false, "Albania", "008", "+355", null, null },
                    { 3, "DZ", "DZA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "DZD", "د.ج", true, false, "Algeria", "012", "+213", null, null },
                    { 4, "AD", "AND", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Andorra", "020", "+376", null, null },
                    { 5, "AO", "AGO", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "AOA", "Kz", true, false, "Angola", "024", "+244", null, null },
                    { 6, "AG", "ATG", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XCD", "$", true, false, "Antigua and Barbuda", "028", "+1-268", null, null },
                    { 7, "AR", "ARG", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "ARS", "$", true, false, "Argentina", "032", "+54", null, null },
                    { 8, "AM", "ARM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "AMD", "֏", true, false, "Armenia", "051", "+374", null, null },
                    { 9, "AU", "AUS", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "AUD", "$", true, false, "Australia", "036", "+61", null, null },
                    { 10, "AT", "AUT", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Austria", "040", "+43", null, null },
                    { 11, "AZ", "AZE", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "AZN", "₼", true, false, "Azerbaijan", "031", "+994", null, null },
                    { 12, "BS", "BHS", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BSD", "$", true, false, "Bahamas", "044", "+1-242", null, null },
                    { 13, "BH", "BHR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BHD", "ب.د", true, false, "Bahrain", "048", "+973", null, null },
                    { 14, "BD", "BGD", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BDT", "৳", true, false, "Bangladesh", "050", "+880", null, null },
                    { 15, "BB", "BRB", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BBD", "$", true, false, "Barbados", "052", "+1-246", null, null },
                    { 16, "BY", "BLR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BYN", "Br", true, false, "Belarus", "112", "+375", null, null },
                    { 17, "BE", "BEL", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Belgium", "056", "+32", null, null },
                    { 18, "BZ", "BLZ", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BZD", "$", true, false, "Belize", "084", "+501", null, null },
                    { 19, "BJ", "BEN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XOF", "Fr", true, false, "Benin", "204", "+229", null, null },
                    { 20, "BT", "BTN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BTN", "Nu.", true, false, "Bhutan", "064", "+975", null, null },
                    { 21, "BO", "BOL", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BOB", "Bs.", true, false, "Bolivia", "068", "+591", null, null },
                    { 22, "BA", "BIH", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BAM", "KM", true, false, "Bosnia and Herzegovina", "070", "+387", null, null },
                    { 23, "BW", "BWA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BWP", "P", true, false, "Botswana", "072", "+267", null, null },
                    { 24, "BR", "BRA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BRL", "R$", true, false, "Brazil", "076", "+55", null, null },
                    { 25, "BN", "BRN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BND", "$", true, false, "Brunei", "096", "+673", null, null },
                    { 26, "BG", "BGR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BGN", "лв", true, false, "Bulgaria", "100", "+359", null, null },
                    { 27, "BF", "BFA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XOF", "Fr", true, false, "Burkina Faso", "854", "+226", null, null },
                    { 28, "BI", "BDI", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "BIF", "Fr", true, false, "Burundi", "108", "+257", null, null },
                    { 29, "CV", "CPV", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "CVE", "$", true, false, "Cabo Verde", "132", "+238", null, null },
                    { 30, "KH", "KHM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "KHR", "៛", true, false, "Cambodia", "116", "+855", null, null },
                    { 31, "CM", "CMR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XAF", "Fr", true, false, "Cameroon", "120", "+237", null, null },
                    { 32, "CA", "CAN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "CAD", "$", true, false, "Canada", "124", "+1", null, null },
                    { 33, "CF", "CAF", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XAF", "Fr", true, false, "Central African Republic", "140", "+236", null, null },
                    { 34, "TD", "TCD", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XAF", "Fr", true, false, "Chad", "148", "+235", null, null },
                    { 35, "CL", "CHL", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "CLP", "$", true, false, "Chile", "152", "+56", null, null },
                    { 36, "CN", "CHN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "CNY", "¥", true, false, "China", "156", "+86", null, null },
                    { 37, "CO", "COL", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "COP", "$", true, false, "Colombia", "170", "+57", null, null },
                    { 38, "KM", "COM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "KMF", "Fr", true, false, "Comoros", "174", "+269", null, null },
                    { 39, "CG", "COG", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XAF", "Fr", true, false, "Congo", "178", "+242", null, null },
                    { 40, "CD", "COD", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "CDF", "Fr", true, false, "Congo (Democratic Republic)", "180", "+243", null, null },
                    { 41, "CR", "CRI", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "CRC", "₡", true, false, "Costa Rica", "188", "+506", null, null },
                    { 42, "HR", "HRV", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Croatia", "191", "+385", null, null },
                    { 43, "CU", "CUB", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "CUP", "$", true, false, "Cuba", "192", "+53", null, null },
                    { 44, "CY", "CYP", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Cyprus", "196", "+357", null, null },
                    { 45, "CZ", "CZE", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "CZK", "Kč", true, false, "Czech Republic", "203", "+420", null, null },
                    { 46, "DK", "DNK", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "DKK", "kr", true, false, "Denmark", "208", "+45", null, null },
                    { 47, "DJ", "DJI", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "DJF", "Fr", true, false, "Djibouti", "262", "+253", null, null },
                    { 48, "DM", "DMA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XCD", "$", true, false, "Dominica", "212", "+1-767", null, null },
                    { 49, "DO", "DOM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "DOP", "$", true, false, "Dominican Republic", "214", "+1-809", null, null },
                    { 50, "EC", "ECU", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "USD", "$", true, false, "Ecuador", "218", "+593", null, null },
                    { 51, "EG", "EGY", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EGP", "£", true, false, "Egypt", "818", "+20", null, null },
                    { 52, "SV", "SLV", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "USD", "$", true, false, "El Salvador", "222", "+503", null, null },
                    { 53, "GQ", "GNQ", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XAF", "Fr", true, false, "Equatorial Guinea", "226", "+240", null, null },
                    { 54, "ER", "ERI", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "ERN", "Nfk", true, false, "Eritrea", "232", "+291", null, null },
                    { 55, "EE", "EST", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Estonia", "233", "+372", null, null },
                    { 56, "SZ", "SWZ", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "SZL", "L", true, false, "Eswatini", "748", "+268", null, null },
                    { 57, "ET", "ETH", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "ETB", "Br", true, false, "Ethiopia", "231", "+251", null, null },
                    { 58, "FJ", "FJI", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "FJD", "$", true, false, "Fiji", "242", "+679", null, null },
                    { 59, "FI", "FIN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Finland", "246", "+358", null, null },
                    { 60, "FR", "FRA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "France", "250", "+33", null, null },
                    { 61, "GA", "GAB", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XAF", "Fr", true, false, "Gabon", "266", "+241", null, null },
                    { 62, "GM", "GMB", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "GMD", "D", true, false, "Gambia", "270", "+220", null, null },
                    { 63, "GE", "GEO", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "GEL", "₾", true, false, "Georgia", "268", "+995", null, null },
                    { 64, "DE", "DEU", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Germany", "276", "+49", null, null },
                    { 65, "GH", "GHA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "GHS", "₵", true, false, "Ghana", "288", "+233", null, null },
                    { 66, "GR", "GRC", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Greece", "300", "+30", null, null },
                    { 67, "GD", "GRD", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XCD", "$", true, false, "Grenada", "308", "+1-473", null, null },
                    { 68, "GT", "GTM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "GTQ", "Q", true, false, "Guatemala", "320", "+502", null, null },
                    { 69, "GN", "GIN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "GNF", "Fr", true, false, "Guinea", "324", "+224", null, null },
                    { 70, "GW", "GNB", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XOF", "Fr", true, false, "Guinea-Bissau", "624", "+245", null, null },
                    { 71, "GY", "GUY", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "GYD", "$", true, false, "Guyana", "328", "+592", null, null },
                    { 72, "HT", "HTI", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "HTG", "G", true, false, "Haiti", "332", "+509", null, null },
                    { 73, "HN", "HND", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "HNL", "L", true, false, "Honduras", "340", "+504", null, null },
                    { 74, "HU", "HUN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "HUF", "Ft", true, false, "Hungary", "348", "+36", null, null },
                    { 75, "IS", "ISL", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "ISK", "kr", true, false, "Iceland", "352", "+354", null, null },
                    { 76, "IN", "IND", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "INR", "₹", true, false, "India", "356", "+91", null, null },
                    { 77, "ID", "IDN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "IDR", "Rp", true, false, "Indonesia", "360", "+62", null, null },
                    { 78, "IR", "IRN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "IRR", "﷼", true, false, "Iran", "364", "+98", null, null },
                    { 79, "IQ", "IRQ", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "IQD", "ع.د", true, false, "Iraq", "368", "+964", null, null },
                    { 80, "IE", "IRL", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Ireland", "372", "+353", null, null },
                    { 81, "IL", "ISR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "ILS", "₪", true, false, "Israel", "376", "+972", null, null },
                    { 82, "IT", "ITA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Italy", "380", "+39", null, null },
                    { 83, "JM", "JAM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "JMD", "$", true, false, "Jamaica", "388", "+1-876", null, null },
                    { 84, "JP", "JPN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "JPY", "¥", true, false, "Japan", "392", "+81", null, null },
                    { 85, "JO", "JOR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "JOD", "د.ا", true, false, "Jordan", "400", "+962", null, null },
                    { 86, "KZ", "KAZ", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "KZT", "₸", true, false, "Kazakhstan", "398", "+7", null, null },
                    { 87, "KE", "KEN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "KES", "Sh", true, false, "Kenya", "404", "+254", null, null },
                    { 88, "KI", "KIR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "AUD", "$", true, false, "Kiribati", "296", "+686", null, null },
                    { 89, "KP", "PRK", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "KPW", "₩", true, false, "Korea (North)", "408", "+850", null, null },
                    { 90, "KR", "KOR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "KRW", "₩", true, false, "Korea (South)", "410", "+82", null, null },
                    { 91, "KW", "KWT", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "KWD", "د.ك", true, false, "Kuwait", "414", "+965", null, null },
                    { 92, "KG", "KGZ", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "KGS", "с", true, false, "Kyrgyzstan", "417", "+996", null, null },
                    { 93, "LA", "LAO", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "LAK", "₭", true, false, "Laos", "418", "+856", null, null },
                    { 94, "LV", "LVA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Latvia", "428", "+371", null, null },
                    { 95, "LB", "LBN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "LBP", "ل.ل", true, false, "Lebanon", "422", "+961", null, null },
                    { 96, "LS", "LSO", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "LSL", "L", true, false, "Lesotho", "426", "+266", null, null },
                    { 97, "LR", "LBR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "LRD", "$", true, false, "Liberia", "430", "+231", null, null },
                    { 98, "LY", "LBY", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "LYD", "ل.د", true, false, "Libya", "434", "+218", null, null },
                    { 99, "LI", "LIE", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "CHF", "Fr", true, false, "Liechtenstein", "438", "+423", null, null },
                    { 100, "LT", "LTU", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Lithuania", "440", "+370", null, null },
                    { 101, "LU", "LUX", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Luxembourg", "442", "+352", null, null },
                    { 102, "MG", "MDG", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MGA", "Ar", true, false, "Madagascar", "450", "+261", null, null },
                    { 103, "MW", "MWI", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MWK", "MK", true, false, "Malawi", "454", "+265", null, null },
                    { 104, "MY", "MYS", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MYR", "RM", true, false, "Malaysia", "458", "+60", null, null },
                    { 105, "MV", "MDV", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MVR", "ރ.", true, false, "Maldives", "462", "+960", null, null },
                    { 106, "ML", "MLI", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XOF", "Fr", true, false, "Mali", "466", "+223", null, null },
                    { 107, "MT", "MLT", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Malta", "470", "+356", null, null },
                    { 108, "MH", "MHL", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "USD", "$", true, false, "Marshall Islands", "584", "+692", null, null },
                    { 109, "MR", "MRT", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MRU", "UM", true, false, "Mauritania", "478", "+222", null, null },
                    { 110, "MU", "MUS", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MUR", "₨", true, false, "Mauritius", "480", "+230", null, null },
                    { 111, "MX", "MEX", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MXN", "$", true, false, "Mexico", "484", "+52", null, null },
                    { 112, "FM", "FSM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "USD", "$", true, false, "Micronesia", "583", "+691", null, null },
                    { 113, "MD", "MDA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MDL", "L", true, false, "Moldova", "498", "+373", null, null },
                    { 114, "MC", "MCO", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Monaco", "492", "+377", null, null },
                    { 115, "MN", "MNG", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MNT", "₮", true, false, "Mongolia", "496", "+976", null, null },
                    { 116, "ME", "MNE", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Montenegro", "499", "+382", null, null },
                    { 117, "MA", "MAR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MAD", "د.م.", true, false, "Morocco", "504", "+212", null, null },
                    { 118, "MZ", "MOZ", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MZN", "MT", true, false, "Mozambique", "508", "+258", null, null },
                    { 119, "MM", "MMR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MMK", "K", true, false, "Myanmar", "104", "+95", null, null },
                    { 120, "NA", "NAM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "NAD", "$", true, false, "Namibia", "516", "+264", null, null },
                    { 121, "NR", "NRU", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "AUD", "$", true, false, "Nauru", "520", "+674", null, null },
                    { 122, "NP", "NPL", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "NPR", "₨", true, false, "Nepal", "524", "+977", null, null },
                    { 123, "NL", "NLD", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Netherlands", "528", "+31", null, null },
                    { 124, "NZ", "NZL", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "NZD", "$", true, false, "New Zealand", "554", "+64", null, null },
                    { 125, "NI", "NIC", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "NIO", "C$", true, false, "Nicaragua", "558", "+505", null, null },
                    { 126, "NE", "NER", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XOF", "Fr", true, false, "Niger", "562", "+227", null, null },
                    { 127, "NG", "NGA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "NGN", "₦", true, false, "Nigeria", "566", "+234", null, null },
                    { 128, "MK", "MKD", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "MKD", "ден", true, false, "North Macedonia", "807", "+389", null, null },
                    { 129, "NO", "NOR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "NOK", "kr", true, false, "Norway", "578", "+47", null, null },
                    { 130, "OM", "OMN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "OMR", "ر.ع.", true, false, "Oman", "512", "+968", null, null },
                    { 131, "PK", "PAK", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "PKR", "₨", true, false, "Pakistan", "586", "+92", null, null },
                    { 132, "PW", "PLW", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "USD", "$", true, false, "Palau", "585", "+680", null, null },
                    { 133, "PA", "PAN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "PAB", "B/.", true, false, "Panama", "591", "+507", null, null },
                    { 134, "PG", "PNG", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "PGK", "K", true, false, "Papua New Guinea", "598", "+675", null, null },
                    { 135, "PY", "PRY", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "PYG", "₲", true, false, "Paraguay", "600", "+595", null, null },
                    { 136, "PE", "PER", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "PEN", "S/", true, false, "Peru", "604", "+51", null, null },
                    { 137, "PH", "PHL", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "PHP", "₱", true, false, "Philippines", "608", "+63", null, null },
                    { 138, "PL", "POL", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "PLN", "zł", true, false, "Poland", "616", "+48", null, null },
                    { 139, "PT", "PRT", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Portugal", "620", "+351", null, null },
                    { 140, "QA", "QAT", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "QAR", "ر.ق", true, false, "Qatar", "634", "+974", null, null },
                    { 141, "RO", "ROU", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "RON", "lei", true, false, "Romania", "642", "+40", null, null },
                    { 142, "RU", "RUS", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "RUB", "₽", true, false, "Russia", "643", "+7", null, null },
                    { 143, "RW", "RWA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "RWF", "Fr", true, false, "Rwanda", "646", "+250", null, null },
                    { 144, "KN", "KNA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XCD", "$", true, false, "Saint Kitts and Nevis", "659", "+1-869", null, null },
                    { 145, "LC", "LCA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XCD", "$", true, false, "Saint Lucia", "662", "+1-758", null, null },
                    { 146, "VC", "VCT", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XCD", "$", true, false, "Saint Vincent and the Grenadines", "670", "+1-784", null, null },
                    { 147, "WS", "WSM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "WST", "T", true, false, "Samoa", "882", "+685", null, null },
                    { 148, "SM", "SMR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "San Marino", "674", "+378", null, null },
                    { 149, "ST", "STP", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "STN", "Db", true, false, "Sao Tome and Principe", "678", "+239", null, null },
                    { 150, "SA", "SAU", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "SAR", "ر.س", true, false, "Saudi Arabia", "682", "+966", null, null },
                    { 151, "SN", "SEN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XOF", "Fr", true, false, "Senegal", "686", "+221", null, null },
                    { 152, "RS", "SRB", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "RSD", "дин", true, false, "Serbia", "688", "+381", null, null },
                    { 153, "SC", "SYC", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "SCR", "₨", true, false, "Seychelles", "690", "+248", null, null },
                    { 154, "SL", "SLE", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "SLL", "Le", true, false, "Sierra Leone", "694", "+232", null, null },
                    { 155, "SG", "SGP", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "SGD", "$", true, false, "Singapore", "702", "+65", null, null },
                    { 156, "SK", "SVK", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Slovakia", "703", "+421", null, null },
                    { 157, "SI", "SVN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Slovenia", "705", "+386", null, null },
                    { 158, "SB", "SLB", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "SBD", "$", true, false, "Solomon Islands", "090", "+677", null, null },
                    { 159, "SO", "SOM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "SOS", "Sh", true, false, "Somalia", "706", "+252", null, null },
                    { 160, "ZA", "ZAF", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "ZAR", "R", true, false, "South Africa", "710", "+27", null, null },
                    { 161, "SS", "SSD", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "SSP", "£", true, false, "South Sudan", "728", "+211", null, null },
                    { 162, "ES", "ESP", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Spain", "724", "+34", null, null },
                    { 163, "LK", "LKA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "LKR", "Rs", true, false, "Sri Lanka", "144", "+94", null, null },
                    { 164, "SD", "SDN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "SDG", "ج.س.", true, false, "Sudan", "729", "+249", null, null },
                    { 165, "SR", "SUR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "SRD", "$", true, false, "Suriname", "740", "+597", null, null },
                    { 166, "SE", "SWE", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "SEK", "kr", true, false, "Sweden", "752", "+46", null, null },
                    { 167, "CH", "CHE", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "CHF", "Fr", true, false, "Switzerland", "756", "+41", null, null },
                    { 168, "SY", "SYR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "SYP", "£", true, false, "Syria", "760", "+963", null, null },
                    { 169, "TW", "TWN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "TWD", "NT$", true, false, "Taiwan", "158", "+886", null, null },
                    { 170, "TJ", "TJK", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "TJS", "ЅМ", true, false, "Tajikistan", "762", "+992", null, null },
                    { 171, "TZ", "TZA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "TZS", "Sh", true, false, "Tanzania", "834", "+255", null, null },
                    { 172, "TH", "THA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "THB", "฿", true, false, "Thailand", "764", "+66", null, null },
                    { 173, "TL", "TLS", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "USD", "$", true, false, "Timor-Leste", "626", "+670", null, null },
                    { 174, "TG", "TGO", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "XOF", "Fr", true, false, "Togo", "768", "+228", null, null },
                    { 175, "TO", "TON", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "TOP", "T$", true, false, "Tonga", "776", "+676", null, null },
                    { 176, "TT", "TTO", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "TTD", "$", true, false, "Trinidad and Tobago", "780", "+1-868", null, null },
                    { 177, "TN", "TUN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "TND", "د.ت", true, false, "Tunisia", "788", "+216", null, null },
                    { 178, "TR", "TUR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "TRY", "₺", true, false, "Turkey", "792", "+90", null, null },
                    { 179, "TM", "TKM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "TMT", "m", true, false, "Turkmenistan", "795", "+993", null, null },
                    { 180, "TV", "TUV", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "AUD", "$", true, false, "Tuvalu", "798", "+688", null, null },
                    { 181, "UG", "UGA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "UGX", "Sh", true, false, "Uganda", "800", "+256", null, null },
                    { 182, "UA", "UKR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "UAH", "₴", true, false, "Ukraine", "804", "+380", null, null },
                    { 183, "AE", "ARE", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "AED", "د.إ", true, false, "United Arab Emirates", "784", "+971", null, null },
                    { 184, "GB", "GBR", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "GBP", "£", true, false, "United Kingdom", "826", "+44", null, null },
                    { 185, "US", "USA", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "USD", "$", true, false, "United States", "840", "+1", null, null },
                    { 186, "UY", "URY", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "UYU", "$", true, false, "Uruguay", "858", "+598", null, null },
                    { 187, "UZ", "UZB", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "UZS", "so'm", true, false, "Uzbekistan", "860", "+998", null, null },
                    { 188, "VU", "VUT", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "VUV", "Vt", true, false, "Vanuatu", "548", "+678", null, null },
                    { 189, "VA", "VAT", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "EUR", "€", true, false, "Vatican City", "336", "+379", null, null },
                    { 190, "VE", "VEN", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "VES", "Bs.S", true, false, "Venezuela", "862", "+58", null, null },
                    { 191, "VN", "VNM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "VND", "₫", true, false, "Vietnam", "704", "+84", null, null },
                    { 192, "YE", "YEM", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "YER", "﷼", true, false, "Yemen", "887", "+967", null, null },
                    { 193, "ZM", "ZMB", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "ZMW", "ZK", true, false, "Zambia", "894", "+260", null, null },
                    { 194, "ZW", "ZWE", new DateTime(2025, 10, 9, 16, 52, 40, 975, DateTimeKind.Utc).AddTicks(3858), "System", "ZWL", "$", true, false, "Zimbabwe", "716", "+263", null, null }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                table: "Countries",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

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
        }
    }
}
