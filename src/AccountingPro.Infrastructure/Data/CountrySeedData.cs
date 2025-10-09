using AccountingPro.Core.Entities;

namespace AccountingPro.Infrastructure.Data;

public static class CountrySeedData
{
    public static List<Country> GetCountries()
    {
        var now = DateTime.UtcNow;
        var countries = new List<Country>
        {
            // A
            new() { Id = 1, Code = "AF", Name = "Afghanistan", Code3 = "AFG", NumericCode = "004", PhoneCode = "+93", Currency = "AFN", CurrencySymbol = "؋", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 2, Code = "AL", Name = "Albania", Code3 = "ALB", NumericCode = "008", PhoneCode = "+355", Currency = "ALL", CurrencySymbol = "L", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 3, Code = "DZ", Name = "Algeria", Code3 = "DZA", NumericCode = "012", PhoneCode = "+213", Currency = "DZD", CurrencySymbol = "د.ج", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 4, Code = "AD", Name = "Andorra", Code3 = "AND", NumericCode = "020", PhoneCode = "+376", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 5, Code = "AO", Name = "Angola", Code3 = "AGO", NumericCode = "024", PhoneCode = "+244", Currency = "AOA", CurrencySymbol = "Kz", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 6, Code = "AG", Name = "Antigua and Barbuda", Code3 = "ATG", NumericCode = "028", PhoneCode = "+1-268", Currency = "XCD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 7, Code = "AR", Name = "Argentina", Code3 = "ARG", NumericCode = "032", PhoneCode = "+54", Currency = "ARS", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 8, Code = "AM", Name = "Armenia", Code3 = "ARM", NumericCode = "051", PhoneCode = "+374", Currency = "AMD", CurrencySymbol = "֏", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 9, Code = "AU", Name = "Australia", Code3 = "AUS", NumericCode = "036", PhoneCode = "+61", Currency = "AUD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 10, Code = "AT", Name = "Austria", Code3 = "AUT", NumericCode = "040", PhoneCode = "+43", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 11, Code = "AZ", Name = "Azerbaijan", Code3 = "AZE", NumericCode = "031", PhoneCode = "+994", Currency = "AZN", CurrencySymbol = "₼", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // B
            new() { Id = 12, Code = "BS", Name = "Bahamas", Code3 = "BHS", NumericCode = "044", PhoneCode = "+1-242", Currency = "BSD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 13, Code = "BH", Name = "Bahrain", Code3 = "BHR", NumericCode = "048", PhoneCode = "+973", Currency = "BHD", CurrencySymbol = "ب.د", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 14, Code = "BD", Name = "Bangladesh", Code3 = "BGD", NumericCode = "050", PhoneCode = "+880", Currency = "BDT", CurrencySymbol = "৳", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 15, Code = "BB", Name = "Barbados", Code3 = "BRB", NumericCode = "052", PhoneCode = "+1-246", Currency = "BBD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 16, Code = "BY", Name = "Belarus", Code3 = "BLR", NumericCode = "112", PhoneCode = "+375", Currency = "BYN", CurrencySymbol = "Br", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 17, Code = "BE", Name = "Belgium", Code3 = "BEL", NumericCode = "056", PhoneCode = "+32", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 18, Code = "BZ", Name = "Belize", Code3 = "BLZ", NumericCode = "084", PhoneCode = "+501", Currency = "BZD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 19, Code = "BJ", Name = "Benin", Code3 = "BEN", NumericCode = "204", PhoneCode = "+229", Currency = "XOF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 20, Code = "BT", Name = "Bhutan", Code3 = "BTN", NumericCode = "064", PhoneCode = "+975", Currency = "BTN", CurrencySymbol = "Nu.", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 21, Code = "BO", Name = "Bolivia", Code3 = "BOL", NumericCode = "068", PhoneCode = "+591", Currency = "BOB", CurrencySymbol = "Bs.", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 22, Code = "BA", Name = "Bosnia and Herzegovina", Code3 = "BIH", NumericCode = "070", PhoneCode = "+387", Currency = "BAM", CurrencySymbol = "KM", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 23, Code = "BW", Name = "Botswana", Code3 = "BWA", NumericCode = "072", PhoneCode = "+267", Currency = "BWP", CurrencySymbol = "P", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 24, Code = "BR", Name = "Brazil", Code3 = "BRA", NumericCode = "076", PhoneCode = "+55", Currency = "BRL", CurrencySymbol = "R$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 25, Code = "BN", Name = "Brunei", Code3 = "BRN", NumericCode = "096", PhoneCode = "+673", Currency = "BND", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 26, Code = "BG", Name = "Bulgaria", Code3 = "BGR", NumericCode = "100", PhoneCode = "+359", Currency = "BGN", CurrencySymbol = "лв", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 27, Code = "BF", Name = "Burkina Faso", Code3 = "BFA", NumericCode = "854", PhoneCode = "+226", Currency = "XOF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 28, Code = "BI", Name = "Burundi", Code3 = "BDI", NumericCode = "108", PhoneCode = "+257", Currency = "BIF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // C
            new() { Id = 29, Code = "CV", Name = "Cabo Verde", Code3 = "CPV", NumericCode = "132", PhoneCode = "+238", Currency = "CVE", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 30, Code = "KH", Name = "Cambodia", Code3 = "KHM", NumericCode = "116", PhoneCode = "+855", Currency = "KHR", CurrencySymbol = "៛", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 31, Code = "CM", Name = "Cameroon", Code3 = "CMR", NumericCode = "120", PhoneCode = "+237", Currency = "XAF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 32, Code = "CA", Name = "Canada", Code3 = "CAN", NumericCode = "124", PhoneCode = "+1", Currency = "CAD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 33, Code = "CF", Name = "Central African Republic", Code3 = "CAF", NumericCode = "140", PhoneCode = "+236", Currency = "XAF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 34, Code = "TD", Name = "Chad", Code3 = "TCD", NumericCode = "148", PhoneCode = "+235", Currency = "XAF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 35, Code = "CL", Name = "Chile", Code3 = "CHL", NumericCode = "152", PhoneCode = "+56", Currency = "CLP", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 36, Code = "CN", Name = "China", Code3 = "CHN", NumericCode = "156", PhoneCode = "+86", Currency = "CNY", CurrencySymbol = "¥", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 37, Code = "CO", Name = "Colombia", Code3 = "COL", NumericCode = "170", PhoneCode = "+57", Currency = "COP", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 38, Code = "KM", Name = "Comoros", Code3 = "COM", NumericCode = "174", PhoneCode = "+269", Currency = "KMF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 39, Code = "CG", Name = "Congo", Code3 = "COG", NumericCode = "178", PhoneCode = "+242", Currency = "XAF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 40, Code = "CD", Name = "Congo (Democratic Republic)", Code3 = "COD", NumericCode = "180", PhoneCode = "+243", Currency = "CDF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 41, Code = "CR", Name = "Costa Rica", Code3 = "CRI", NumericCode = "188", PhoneCode = "+506", Currency = "CRC", CurrencySymbol = "₡", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 42, Code = "HR", Name = "Croatia", Code3 = "HRV", NumericCode = "191", PhoneCode = "+385", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 43, Code = "CU", Name = "Cuba", Code3 = "CUB", NumericCode = "192", PhoneCode = "+53", Currency = "CUP", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 44, Code = "CY", Name = "Cyprus", Code3 = "CYP", NumericCode = "196", PhoneCode = "+357", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 45, Code = "CZ", Name = "Czech Republic", Code3 = "CZE", NumericCode = "203", PhoneCode = "+420", Currency = "CZK", CurrencySymbol = "Kč", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // D
            new() { Id = 46, Code = "DK", Name = "Denmark", Code3 = "DNK", NumericCode = "208", PhoneCode = "+45", Currency = "DKK", CurrencySymbol = "kr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 47, Code = "DJ", Name = "Djibouti", Code3 = "DJI", NumericCode = "262", PhoneCode = "+253", Currency = "DJF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 48, Code = "DM", Name = "Dominica", Code3 = "DMA", NumericCode = "212", PhoneCode = "+1-767", Currency = "XCD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 49, Code = "DO", Name = "Dominican Republic", Code3 = "DOM", NumericCode = "214", PhoneCode = "+1-809", Currency = "DOP", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // E
            new() { Id = 50, Code = "EC", Name = "Ecuador", Code3 = "ECU", NumericCode = "218", PhoneCode = "+593", Currency = "USD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 51, Code = "EG", Name = "Egypt", Code3 = "EGY", NumericCode = "818", PhoneCode = "+20", Currency = "EGP", CurrencySymbol = "£", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 52, Code = "SV", Name = "El Salvador", Code3 = "SLV", NumericCode = "222", PhoneCode = "+503", Currency = "USD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 53, Code = "GQ", Name = "Equatorial Guinea", Code3 = "GNQ", NumericCode = "226", PhoneCode = "+240", Currency = "XAF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 54, Code = "ER", Name = "Eritrea", Code3 = "ERI", NumericCode = "232", PhoneCode = "+291", Currency = "ERN", CurrencySymbol = "Nfk", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 55, Code = "EE", Name = "Estonia", Code3 = "EST", NumericCode = "233", PhoneCode = "+372", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 56, Code = "SZ", Name = "Eswatini", Code3 = "SWZ", NumericCode = "748", PhoneCode = "+268", Currency = "SZL", CurrencySymbol = "L", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 57, Code = "ET", Name = "Ethiopia", Code3 = "ETH", NumericCode = "231", PhoneCode = "+251", Currency = "ETB", CurrencySymbol = "Br", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // F
            new() { Id = 58, Code = "FJ", Name = "Fiji", Code3 = "FJI", NumericCode = "242", PhoneCode = "+679", Currency = "FJD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 59, Code = "FI", Name = "Finland", Code3 = "FIN", NumericCode = "246", PhoneCode = "+358", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 60, Code = "FR", Name = "France", Code3 = "FRA", NumericCode = "250", PhoneCode = "+33", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // G
            new() { Id = 61, Code = "GA", Name = "Gabon", Code3 = "GAB", NumericCode = "266", PhoneCode = "+241", Currency = "XAF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 62, Code = "GM", Name = "Gambia", Code3 = "GMB", NumericCode = "270", PhoneCode = "+220", Currency = "GMD", CurrencySymbol = "D", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 63, Code = "GE", Name = "Georgia", Code3 = "GEO", NumericCode = "268", PhoneCode = "+995", Currency = "GEL", CurrencySymbol = "₾", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 64, Code = "DE", Name = "Germany", Code3 = "DEU", NumericCode = "276", PhoneCode = "+49", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 65, Code = "GH", Name = "Ghana", Code3 = "GHA", NumericCode = "288", PhoneCode = "+233", Currency = "GHS", CurrencySymbol = "₵", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 66, Code = "GR", Name = "Greece", Code3 = "GRC", NumericCode = "300", PhoneCode = "+30", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 67, Code = "GD", Name = "Grenada", Code3 = "GRD", NumericCode = "308", PhoneCode = "+1-473", Currency = "XCD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 68, Code = "GT", Name = "Guatemala", Code3 = "GTM", NumericCode = "320", PhoneCode = "+502", Currency = "GTQ", CurrencySymbol = "Q", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 69, Code = "GN", Name = "Guinea", Code3 = "GIN", NumericCode = "324", PhoneCode = "+224", Currency = "GNF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 70, Code = "GW", Name = "Guinea-Bissau", Code3 = "GNB", NumericCode = "624", PhoneCode = "+245", Currency = "XOF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 71, Code = "GY", Name = "Guyana", Code3 = "GUY", NumericCode = "328", PhoneCode = "+592", Currency = "GYD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // H
            new() { Id = 72, Code = "HT", Name = "Haiti", Code3 = "HTI", NumericCode = "332", PhoneCode = "+509", Currency = "HTG", CurrencySymbol = "G", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 73, Code = "HN", Name = "Honduras", Code3 = "HND", NumericCode = "340", PhoneCode = "+504", Currency = "HNL", CurrencySymbol = "L", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 74, Code = "HU", Name = "Hungary", Code3 = "HUN", NumericCode = "348", PhoneCode = "+36", Currency = "HUF", CurrencySymbol = "Ft", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // I
            new() { Id = 75, Code = "IS", Name = "Iceland", Code3 = "ISL", NumericCode = "352", PhoneCode = "+354", Currency = "ISK", CurrencySymbol = "kr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 76, Code = "IN", Name = "India", Code3 = "IND", NumericCode = "356", PhoneCode = "+91", Currency = "INR", CurrencySymbol = "₹", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 77, Code = "ID", Name = "Indonesia", Code3 = "IDN", NumericCode = "360", PhoneCode = "+62", Currency = "IDR", CurrencySymbol = "Rp", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 78, Code = "IR", Name = "Iran", Code3 = "IRN", NumericCode = "364", PhoneCode = "+98", Currency = "IRR", CurrencySymbol = "﷼", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 79, Code = "IQ", Name = "Iraq", Code3 = "IRQ", NumericCode = "368", PhoneCode = "+964", Currency = "IQD", CurrencySymbol = "ع.د", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 80, Code = "IE", Name = "Ireland", Code3 = "IRL", NumericCode = "372", PhoneCode = "+353", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 81, Code = "IL", Name = "Israel", Code3 = "ISR", NumericCode = "376", PhoneCode = "+972", Currency = "ILS", CurrencySymbol = "₪", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 82, Code = "IT", Name = "Italy", Code3 = "ITA", NumericCode = "380", PhoneCode = "+39", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // J
            new() { Id = 83, Code = "JM", Name = "Jamaica", Code3 = "JAM", NumericCode = "388", PhoneCode = "+1-876", Currency = "JMD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 84, Code = "JP", Name = "Japan", Code3 = "JPN", NumericCode = "392", PhoneCode = "+81", Currency = "JPY", CurrencySymbol = "¥", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 85, Code = "JO", Name = "Jordan", Code3 = "JOR", NumericCode = "400", PhoneCode = "+962", Currency = "JOD", CurrencySymbol = "د.ا", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // K
            new() { Id = 86, Code = "KZ", Name = "Kazakhstan", Code3 = "KAZ", NumericCode = "398", PhoneCode = "+7", Currency = "KZT", CurrencySymbol = "₸", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 87, Code = "KE", Name = "Kenya", Code3 = "KEN", NumericCode = "404", PhoneCode = "+254", Currency = "KES", CurrencySymbol = "Sh", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 88, Code = "KI", Name = "Kiribati", Code3 = "KIR", NumericCode = "296", PhoneCode = "+686", Currency = "AUD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 89, Code = "KP", Name = "Korea (North)", Code3 = "PRK", NumericCode = "408", PhoneCode = "+850", Currency = "KPW", CurrencySymbol = "₩", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 90, Code = "KR", Name = "Korea (South)", Code3 = "KOR", NumericCode = "410", PhoneCode = "+82", Currency = "KRW", CurrencySymbol = "₩", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 91, Code = "KW", Name = "Kuwait", Code3 = "KWT", NumericCode = "414", PhoneCode = "+965", Currency = "KWD", CurrencySymbol = "د.ك", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 92, Code = "KG", Name = "Kyrgyzstan", Code3 = "KGZ", NumericCode = "417", PhoneCode = "+996", Currency = "KGS", CurrencySymbol = "с", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // L
            new() { Id = 93, Code = "LA", Name = "Laos", Code3 = "LAO", NumericCode = "418", PhoneCode = "+856", Currency = "LAK", CurrencySymbol = "₭", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 94, Code = "LV", Name = "Latvia", Code3 = "LVA", NumericCode = "428", PhoneCode = "+371", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 95, Code = "LB", Name = "Lebanon", Code3 = "LBN", NumericCode = "422", PhoneCode = "+961", Currency = "LBP", CurrencySymbol = "ل.ل", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 96, Code = "LS", Name = "Lesotho", Code3 = "LSO", NumericCode = "426", PhoneCode = "+266", Currency = "LSL", CurrencySymbol = "L", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 97, Code = "LR", Name = "Liberia", Code3 = "LBR", NumericCode = "430", PhoneCode = "+231", Currency = "LRD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 98, Code = "LY", Name = "Libya", Code3 = "LBY", NumericCode = "434", PhoneCode = "+218", Currency = "LYD", CurrencySymbol = "ل.د", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 99, Code = "LI", Name = "Liechtenstein", Code3 = "LIE", NumericCode = "438", PhoneCode = "+423", Currency = "CHF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 100, Code = "LT", Name = "Lithuania", Code3 = "LTU", NumericCode = "440", PhoneCode = "+370", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 101, Code = "LU", Name = "Luxembourg", Code3 = "LUX", NumericCode = "442", PhoneCode = "+352", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // M
            new() { Id = 102, Code = "MG", Name = "Madagascar", Code3 = "MDG", NumericCode = "450", PhoneCode = "+261", Currency = "MGA", CurrencySymbol = "Ar", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 103, Code = "MW", Name = "Malawi", Code3 = "MWI", NumericCode = "454", PhoneCode = "+265", Currency = "MWK", CurrencySymbol = "MK", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 104, Code = "MY", Name = "Malaysia", Code3 = "MYS", NumericCode = "458", PhoneCode = "+60", Currency = "MYR", CurrencySymbol = "RM", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 105, Code = "MV", Name = "Maldives", Code3 = "MDV", NumericCode = "462", PhoneCode = "+960", Currency = "MVR", CurrencySymbol = "ރ.", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 106, Code = "ML", Name = "Mali", Code3 = "MLI", NumericCode = "466", PhoneCode = "+223", Currency = "XOF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 107, Code = "MT", Name = "Malta", Code3 = "MLT", NumericCode = "470", PhoneCode = "+356", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 108, Code = "MH", Name = "Marshall Islands", Code3 = "MHL", NumericCode = "584", PhoneCode = "+692", Currency = "USD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 109, Code = "MR", Name = "Mauritania", Code3 = "MRT", NumericCode = "478", PhoneCode = "+222", Currency = "MRU", CurrencySymbol = "UM", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 110, Code = "MU", Name = "Mauritius", Code3 = "MUS", NumericCode = "480", PhoneCode = "+230", Currency = "MUR", CurrencySymbol = "₨", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 111, Code = "MX", Name = "Mexico", Code3 = "MEX", NumericCode = "484", PhoneCode = "+52", Currency = "MXN", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 112, Code = "FM", Name = "Micronesia", Code3 = "FSM", NumericCode = "583", PhoneCode = "+691", Currency = "USD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 113, Code = "MD", Name = "Moldova", Code3 = "MDA", NumericCode = "498", PhoneCode = "+373", Currency = "MDL", CurrencySymbol = "L", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 114, Code = "MC", Name = "Monaco", Code3 = "MCO", NumericCode = "492", PhoneCode = "+377", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 115, Code = "MN", Name = "Mongolia", Code3 = "MNG", NumericCode = "496", PhoneCode = "+976", Currency = "MNT", CurrencySymbol = "₮", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 116, Code = "ME", Name = "Montenegro", Code3 = "MNE", NumericCode = "499", PhoneCode = "+382", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 117, Code = "MA", Name = "Morocco", Code3 = "MAR", NumericCode = "504", PhoneCode = "+212", Currency = "MAD", CurrencySymbol = "د.م.", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 118, Code = "MZ", Name = "Mozambique", Code3 = "MOZ", NumericCode = "508", PhoneCode = "+258", Currency = "MZN", CurrencySymbol = "MT", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 119, Code = "MM", Name = "Myanmar", Code3 = "MMR", NumericCode = "104", PhoneCode = "+95", Currency = "MMK", CurrencySymbol = "K", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // N
            new() { Id = 120, Code = "NA", Name = "Namibia", Code3 = "NAM", NumericCode = "516", PhoneCode = "+264", Currency = "NAD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 121, Code = "NR", Name = "Nauru", Code3 = "NRU", NumericCode = "520", PhoneCode = "+674", Currency = "AUD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 122, Code = "NP", Name = "Nepal", Code3 = "NPL", NumericCode = "524", PhoneCode = "+977", Currency = "NPR", CurrencySymbol = "₨", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 123, Code = "NL", Name = "Netherlands", Code3 = "NLD", NumericCode = "528", PhoneCode = "+31", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 124, Code = "NZ", Name = "New Zealand", Code3 = "NZL", NumericCode = "554", PhoneCode = "+64", Currency = "NZD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 125, Code = "NI", Name = "Nicaragua", Code3 = "NIC", NumericCode = "558", PhoneCode = "+505", Currency = "NIO", CurrencySymbol = "C$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 126, Code = "NE", Name = "Niger", Code3 = "NER", NumericCode = "562", PhoneCode = "+227", Currency = "XOF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 127, Code = "NG", Name = "Nigeria", Code3 = "NGA", NumericCode = "566", PhoneCode = "+234", Currency = "NGN", CurrencySymbol = "₦", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 128, Code = "MK", Name = "North Macedonia", Code3 = "MKD", NumericCode = "807", PhoneCode = "+389", Currency = "MKD", CurrencySymbol = "ден", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 129, Code = "NO", Name = "Norway", Code3 = "NOR", NumericCode = "578", PhoneCode = "+47", Currency = "NOK", CurrencySymbol = "kr", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // O
            new() { Id = 130, Code = "OM", Name = "Oman", Code3 = "OMN", NumericCode = "512", PhoneCode = "+968", Currency = "OMR", CurrencySymbol = "ر.ع.", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // P
            new() { Id = 131, Code = "PK", Name = "Pakistan", Code3 = "PAK", NumericCode = "586", PhoneCode = "+92", Currency = "PKR", CurrencySymbol = "₨", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 132, Code = "PW", Name = "Palau", Code3 = "PLW", NumericCode = "585", PhoneCode = "+680", Currency = "USD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 133, Code = "PA", Name = "Panama", Code3 = "PAN", NumericCode = "591", PhoneCode = "+507", Currency = "PAB", CurrencySymbol = "B/.", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 134, Code = "PG", Name = "Papua New Guinea", Code3 = "PNG", NumericCode = "598", PhoneCode = "+675", Currency = "PGK", CurrencySymbol = "K", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 135, Code = "PY", Name = "Paraguay", Code3 = "PRY", NumericCode = "600", PhoneCode = "+595", Currency = "PYG", CurrencySymbol = "₲", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 136, Code = "PE", Name = "Peru", Code3 = "PER", NumericCode = "604", PhoneCode = "+51", Currency = "PEN", CurrencySymbol = "S/", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 137, Code = "PH", Name = "Philippines", Code3 = "PHL", NumericCode = "608", PhoneCode = "+63", Currency = "PHP", CurrencySymbol = "₱", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 138, Code = "PL", Name = "Poland", Code3 = "POL", NumericCode = "616", PhoneCode = "+48", Currency = "PLN", CurrencySymbol = "zł", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 139, Code = "PT", Name = "Portugal", Code3 = "PRT", NumericCode = "620", PhoneCode = "+351", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // Q
            new() { Id = 140, Code = "QA", Name = "Qatar", Code3 = "QAT", NumericCode = "634", PhoneCode = "+974", Currency = "QAR", CurrencySymbol = "ر.ق", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // R
            new() { Id = 141, Code = "RO", Name = "Romania", Code3 = "ROU", NumericCode = "642", PhoneCode = "+40", Currency = "RON", CurrencySymbol = "lei", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 142, Code = "RU", Name = "Russia", Code3 = "RUS", NumericCode = "643", PhoneCode = "+7", Currency = "RUB", CurrencySymbol = "₽", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 143, Code = "RW", Name = "Rwanda", Code3 = "RWA", NumericCode = "646", PhoneCode = "+250", Currency = "RWF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // S
            new() { Id = 144, Code = "KN", Name = "Saint Kitts and Nevis", Code3 = "KNA", NumericCode = "659", PhoneCode = "+1-869", Currency = "XCD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 145, Code = "LC", Name = "Saint Lucia", Code3 = "LCA", NumericCode = "662", PhoneCode = "+1-758", Currency = "XCD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 146, Code = "VC", Name = "Saint Vincent and the Grenadines", Code3 = "VCT", NumericCode = "670", PhoneCode = "+1-784", Currency = "XCD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 147, Code = "WS", Name = "Samoa", Code3 = "WSM", NumericCode = "882", PhoneCode = "+685", Currency = "WST", CurrencySymbol = "T", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 148, Code = "SM", Name = "San Marino", Code3 = "SMR", NumericCode = "674", PhoneCode = "+378", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 149, Code = "ST", Name = "Sao Tome and Principe", Code3 = "STP", NumericCode = "678", PhoneCode = "+239", Currency = "STN", CurrencySymbol = "Db", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 150, Code = "SA", Name = "Saudi Arabia", Code3 = "SAU", NumericCode = "682", PhoneCode = "+966", Currency = "SAR", CurrencySymbol = "ر.س", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 151, Code = "SN", Name = "Senegal", Code3 = "SEN", NumericCode = "686", PhoneCode = "+221", Currency = "XOF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 152, Code = "RS", Name = "Serbia", Code3 = "SRB", NumericCode = "688", PhoneCode = "+381", Currency = "RSD", CurrencySymbol = "дин", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 153, Code = "SC", Name = "Seychelles", Code3 = "SYC", NumericCode = "690", PhoneCode = "+248", Currency = "SCR", CurrencySymbol = "₨", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 154, Code = "SL", Name = "Sierra Leone", Code3 = "SLE", NumericCode = "694", PhoneCode = "+232", Currency = "SLL", CurrencySymbol = "Le", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 155, Code = "SG", Name = "Singapore", Code3 = "SGP", NumericCode = "702", PhoneCode = "+65", Currency = "SGD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 156, Code = "SK", Name = "Slovakia", Code3 = "SVK", NumericCode = "703", PhoneCode = "+421", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 157, Code = "SI", Name = "Slovenia", Code3 = "SVN", NumericCode = "705", PhoneCode = "+386", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 158, Code = "SB", Name = "Solomon Islands", Code3 = "SLB", NumericCode = "090", PhoneCode = "+677", Currency = "SBD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 159, Code = "SO", Name = "Somalia", Code3 = "SOM", NumericCode = "706", PhoneCode = "+252", Currency = "SOS", CurrencySymbol = "Sh", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 160, Code = "ZA", Name = "South Africa", Code3 = "ZAF", NumericCode = "710", PhoneCode = "+27", Currency = "ZAR", CurrencySymbol = "R", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 161, Code = "SS", Name = "South Sudan", Code3 = "SSD", NumericCode = "728", PhoneCode = "+211", Currency = "SSP", CurrencySymbol = "£", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 162, Code = "ES", Name = "Spain", Code3 = "ESP", NumericCode = "724", PhoneCode = "+34", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 163, Code = "LK", Name = "Sri Lanka", Code3 = "LKA", NumericCode = "144", PhoneCode = "+94", Currency = "LKR", CurrencySymbol = "Rs", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 164, Code = "SD", Name = "Sudan", Code3 = "SDN", NumericCode = "729", PhoneCode = "+249", Currency = "SDG", CurrencySymbol = "ج.س.", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 165, Code = "SR", Name = "Suriname", Code3 = "SUR", NumericCode = "740", PhoneCode = "+597", Currency = "SRD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 166, Code = "SE", Name = "Sweden", Code3 = "SWE", NumericCode = "752", PhoneCode = "+46", Currency = "SEK", CurrencySymbol = "kr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 167, Code = "CH", Name = "Switzerland", Code3 = "CHE", NumericCode = "756", PhoneCode = "+41", Currency = "CHF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 168, Code = "SY", Name = "Syria", Code3 = "SYR", NumericCode = "760", PhoneCode = "+963", Currency = "SYP", CurrencySymbol = "£", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // T
            new() { Id = 169, Code = "TW", Name = "Taiwan", Code3 = "TWN", NumericCode = "158", PhoneCode = "+886", Currency = "TWD", CurrencySymbol = "NT$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 170, Code = "TJ", Name = "Tajikistan", Code3 = "TJK", NumericCode = "762", PhoneCode = "+992", Currency = "TJS", CurrencySymbol = "ЅМ", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 171, Code = "TZ", Name = "Tanzania", Code3 = "TZA", NumericCode = "834", PhoneCode = "+255", Currency = "TZS", CurrencySymbol = "Sh", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 172, Code = "TH", Name = "Thailand", Code3 = "THA", NumericCode = "764", PhoneCode = "+66", Currency = "THB", CurrencySymbol = "฿", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 173, Code = "TL", Name = "Timor-Leste", Code3 = "TLS", NumericCode = "626", PhoneCode = "+670", Currency = "USD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 174, Code = "TG", Name = "Togo", Code3 = "TGO", NumericCode = "768", PhoneCode = "+228", Currency = "XOF", CurrencySymbol = "Fr", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 175, Code = "TO", Name = "Tonga", Code3 = "TON", NumericCode = "776", PhoneCode = "+676", Currency = "TOP", CurrencySymbol = "T$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 176, Code = "TT", Name = "Trinidad and Tobago", Code3 = "TTO", NumericCode = "780", PhoneCode = "+1-868", Currency = "TTD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 177, Code = "TN", Name = "Tunisia", Code3 = "TUN", NumericCode = "788", PhoneCode = "+216", Currency = "TND", CurrencySymbol = "د.ت", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 178, Code = "TR", Name = "Turkey", Code3 = "TUR", NumericCode = "792", PhoneCode = "+90", Currency = "TRY", CurrencySymbol = "₺", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 179, Code = "TM", Name = "Turkmenistan", Code3 = "TKM", NumericCode = "795", PhoneCode = "+993", Currency = "TMT", CurrencySymbol = "m", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 180, Code = "TV", Name = "Tuvalu", Code3 = "TUV", NumericCode = "798", PhoneCode = "+688", Currency = "AUD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // U
            new() { Id = 181, Code = "UG", Name = "Uganda", Code3 = "UGA", NumericCode = "800", PhoneCode = "+256", Currency = "UGX", CurrencySymbol = "Sh", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 182, Code = "UA", Name = "Ukraine", Code3 = "UKR", NumericCode = "804", PhoneCode = "+380", Currency = "UAH", CurrencySymbol = "₴", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 183, Code = "AE", Name = "United Arab Emirates", Code3 = "ARE", NumericCode = "784", PhoneCode = "+971", Currency = "AED", CurrencySymbol = "د.إ", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 184, Code = "GB", Name = "United Kingdom", Code3 = "GBR", NumericCode = "826", PhoneCode = "+44", Currency = "GBP", CurrencySymbol = "£", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 185, Code = "US", Name = "United States", Code3 = "USA", NumericCode = "840", PhoneCode = "+1", Currency = "USD", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 186, Code = "UY", Name = "Uruguay", Code3 = "URY", NumericCode = "858", PhoneCode = "+598", Currency = "UYU", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 187, Code = "UZ", Name = "Uzbekistan", Code3 = "UZB", NumericCode = "860", PhoneCode = "+998", Currency = "UZS", CurrencySymbol = "so'm", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // V
            new() { Id = 188, Code = "VU", Name = "Vanuatu", Code3 = "VUT", NumericCode = "548", PhoneCode = "+678", Currency = "VUV", CurrencySymbol = "Vt", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 189, Code = "VA", Name = "Vatican City", Code3 = "VAT", NumericCode = "336", PhoneCode = "+379", Currency = "EUR", CurrencySymbol = "€", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 190, Code = "VE", Name = "Venezuela", Code3 = "VEN", NumericCode = "862", PhoneCode = "+58", Currency = "VES", CurrencySymbol = "Bs.S", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 191, Code = "VN", Name = "Vietnam", Code3 = "VNM", NumericCode = "704", PhoneCode = "+84", Currency = "VND", CurrencySymbol = "₫", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // Y
            new() { Id = 192, Code = "YE", Name = "Yemen", Code3 = "YEM", NumericCode = "887", PhoneCode = "+967", Currency = "YER", CurrencySymbol = "﷼", IsActive = true, CreatedAt = now, CreatedBy = "System" },

            // Z
            new() { Id = 193, Code = "ZM", Name = "Zambia", Code3 = "ZMB", NumericCode = "894", PhoneCode = "+260", Currency = "ZMW", CurrencySymbol = "ZK", IsActive = true, CreatedAt = now, CreatedBy = "System" },
            new() { Id = 194, Code = "ZW", Name = "Zimbabwe", Code3 = "ZWE", NumericCode = "716", PhoneCode = "+263", Currency = "ZWL", CurrencySymbol = "$", IsActive = true, CreatedAt = now, CreatedBy = "System" }
        };

        return countries;
    }
}
