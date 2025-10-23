# Invoice Templates

This folder contains professional invoice templates for printing and PDF export.

## Available Templates

### 1. ModernTemplate.cshtml
A contemporary, colorful invoice design featuring:
- Clean, modern layout with blue accent colors
- Professional typography with Segoe UI font
- Color-coded sections for easy reading
- Status badges (Paid, Pending, Overdue)
- Responsive design for various screen sizes
- Ideal for: Tech companies, startups, modern businesses

**Key Features:**
- Blue and gray color scheme
- Highlighted totals section
- Warning-styled notes section (yellow background)
- Information boxes with colored borders
- Hover effects on table rows

### 2. ClassicTemplate.cshtml
A traditional, formal invoice design featuring:
- Professional serif typography (Times New Roman)
- Black and white color scheme
- Double border header
- Formal layout with signature lines
- Rotated status stamps (PAID, OVERDUE)
- Ideal for: Law firms, accounting firms, traditional businesses

**Key Features:**
- Formal table borders
- Signature section for authorized signatures
- Status stamps with rotation effect
- Grid-based information layout
- Dashed border for terms section

## Template Usage

### Data Model
Both templates use the `AccountingPro.Application.DTOs.InvoiceDto` model with the following properties:

**Company Information:**
- CompanyName
- CompanyAddress
- CompanyPhone
- CompanyEmail
- CompanyTaxId

**Invoice Information:**
- InvoiceNumber
- InvoiceDate
- DueDate
- Status (Paid, Pending, Overdue)
- Terms
- Notes

**Customer Information:**
- CustomerName
- CustomerCompany
- CustomerAddress
- CustomerCity
- CustomerState
- CustomerZipCode
- CustomerCountry
- CustomerEmail
- CustomerPhone

**Financial Information:**
- SubTotal
- TaxAmount
- DiscountAmount
- TotalAmount
- PaidAmount
- BalanceAmount
- Items (List of invoice line items)

**Line Item Properties:**
- ProductName
- Description
- Quantity
- UnitPrice
- TaxAmount
- Discount
- LineTotal

## How to Use in Code

### Example: Render Template to HTML

```csharp
public class InvoiceService
{
    private readonly IRazorViewEngine _razorViewEngine;
    private readonly ITempDataProvider _tempDataProvider;
    private readonly IServiceProvider _serviceProvider;

    public async Task<string> RenderInvoiceToHtml(InvoiceDto invoice, string templateName)
    {
        var templatePath = $"~/Templates/Invoices/{templateName}.cshtml";
        
        using var sw = new StringWriter();
        var viewContext = new ViewContext
        {
            HttpContext = new DefaultHttpContext { RequestServices = _serviceProvider },
            Writer = sw
        };
        
        // Render the view with the invoice model
        var viewResult = _razorViewEngine.FindView(viewContext, templatePath, false);
        
        if (viewResult.View != null)
        {
            var viewDataDictionary = new ViewDataDictionary<InvoiceDto>(
                new EmptyModelMetadataProvider(),
                new ModelStateDictionary())
            {
                Model = invoice
            };
            
            var tempData = new TempDataDictionary(viewContext.HttpContext, _tempDataProvider);
            
            var viewContextNew = new ViewContext(
                viewContext,
                viewResult.View,
                viewDataDictionary,
                tempData,
                sw,
                new HtmlHelperOptions()
            );
            
            await viewResult.View.RenderAsync(viewContextNew);
            return sw.ToString();
        }
        
        throw new Exception($"Template {templateName} not found");
    }
}
```

### Example: Generate PDF using DinkToPdf or similar

```csharp
public async Task<byte[]> GenerateInvoicePdf(InvoiceDto invoice, string templateName = "ModernTemplate")
{
    // Render HTML from template
    var html = await RenderInvoiceToHtml(invoice, templateName);
    
    // Convert HTML to PDF using your preferred library
    var converter = new HtmlToPdfConverter();
    var pdfBytes = converter.ConvertToPdf(html);
    
    return pdfBytes;
}
```

### Example: Print Invoice

```csharp
public async Task<IActionResult> PrintInvoice(int invoiceId, string template = "ModernTemplate")
{
    var invoice = await _invoiceService.GetInvoiceById(invoiceId);
    var html = await RenderInvoiceToHtml(invoice, template);
    
    return Content(html, "text/html");
}
```

## Customization

### Changing Colors
Edit the CSS variables in each template:

**ModernTemplate.cshtml:**
```css
.header {
    border-bottom: 3px solid #2c3e50; /* Change header border color */
}

.invoice-label {
    color: #3498db; /* Change INVOICE label color */
}
```

**ClassicTemplate.cshtml:**
```css
.status-stamp.paid {
    color: #28a745; /* Change paid stamp color */
    border-color: #28a745;
}
```

### Adding Company Logo
Add the logo section in the header:

```html
<div class="header">
    <img src="@Model.CompanyLogoUrl" alt="Company Logo" style="max-height: 80px;" />
    <div class="company-name">@Model.CompanyName</div>
    <!-- rest of header -->
</div>
```

### Custom Footer
Modify the footer section to add payment instructions, bank details, etc.:

```html
<div class="footer">
    <p><strong>Payment Instructions:</strong></p>
    <p>Bank: ABC Bank | Account: 1234567890 | Routing: 123456789</p>
    <p>Or pay online at: www.yourcompany.com/pay</p>
</div>
```

## Print Settings

For best print results:
- Paper Size: A4 (210mm × 297mm)
- Margins: 20mm all sides (ModernTemplate), 15mm all sides (ClassicTemplate)
- Print Background Graphics: Enabled
- Scale: 100%

## Browser Compatibility

Both templates are compatible with:
- Chrome/Edge (recommended for PDF generation)
- Firefox
- Safari
- Internet Explorer 11+ (limited support)

## Notes

- Templates use responsive design but are optimized for A4 print
- All monetary values should be formatted with currency symbols
- Dates use culture-specific formatting (e.g., "MMM dd, yyyy")
- Templates are print-friendly with `@media print` styles
- Status stamps in ClassicTemplate use absolute positioning

## Future Enhancements

Potential additions:
- Add QR code for online payment
- Include barcode for invoice number
- Multi-language support
- Company logo placeholder
- Payment method icons
- Digital signature support
