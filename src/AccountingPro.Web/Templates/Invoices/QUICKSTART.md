# Invoice Templates - Quick Reference

## Template Comparison

| Feature | Modern Template | Classic Template |
|---------|----------------|------------------|
| **Style** | Contemporary, colorful | Traditional, formal |
| **Font** | Segoe UI (sans-serif) | Times New Roman (serif) |
| **Color Scheme** | Blue (#3498db) & Gray (#2c3e50) | Black & White |
| **Best For** | Tech companies, Startups | Law firms, Professional services |
| **Status Display** | Colored badges | Rotated stamps |
| **Signature Section** | No | Yes (dual signature lines) |
| **Border Style** | Solid colored | Double/dashed borders |

## Quick Start Guide

### 1. Choose Your Template

```csharp
// Use Modern Template
var html = await RenderTemplate(invoice, "ModernTemplate");

// Use Classic Template
var html = await RenderTemplate(invoice, "ClassicTemplate");
```

### 2. Sample Invoice Data

```csharp
var invoice = new InvoiceTemplateDto
{
    // Company Info
    CompanyName = "Acme Corporation",
    CompanyAddress = "123 Business St, Suite 100",
    CompanyPhone = "+1 (555) 123-4567",
    CompanyEmail = "billing@acme.com",
    CompanyTaxId = "TAX-123456",
    
    // Invoice Info
    InvoiceNumber = "INV-2025-001",
    InvoiceDate = DateTime.Now,
    DueDate = DateTime.Now.AddDays(30),
    Status = "Pending",
    Terms = "Net 30 Days",
    Notes = "Thank you for your business!",
    
    // Customer Info
    CustomerName = "John Smith",
    CustomerCompany = "Smith Enterprises",
    CustomerAddress = "456 Client Ave",
    CustomerCity = "New York",
    CustomerState = "NY",
    CustomerZipCode = "10001",
    CustomerEmail = "john@smithent.com",
    CustomerPhone = "+1 (555) 987-6543",
    
    // Financial Info
    SubTotal = 1000.00m,
    TaxAmount = 80.00m,
    DiscountAmount = 50.00m,
    TotalAmount = 1030.00m,
    PaidAmount = 0.00m,
    BalanceAmount = 1030.00m,
    
    // Line Items
    Items = new List<InvoiceLineItemDto>
    {
        new()
        {
            ProductName = "Professional Services",
            Description = "Consulting services for October 2025",
            Quantity = 10,
            UnitPrice = 100.00m,
            TaxAmount = 80.00m,
            TaxRate = 8.00m,
            Discount = 50.00m,
            LineTotal = 1030.00m
        }
    }
};
```

### 3. Render to HTML

```csharp
public class InvoiceTemplateService
{
    public async Task<string> RenderTemplate(InvoiceTemplateDto invoice, string templateName)
    {
        var templatePath = $"~/Templates/Invoices/{templateName}.cshtml";
        
        // Use Razor engine to render the template
        // Implementation depends on your rendering setup
        
        return htmlOutput;
    }
}
```

### 4. Export to PDF

```csharp
// Using DinkToPdf (recommended)
public byte[] ConvertToPdf(string html)
{
    var converter = new SynchronizedConverter(new PdfTools());
    
    var document = new HtmlToPdfDocument()
    {
        GlobalSettings = {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 }
        },
        Objects = {
            new ObjectSettings() {
                PagesCount = true,
                HtmlContent = html,
                WebSettings = { DefaultEncoding = "utf-8" }
            }
        }
    };
    
    return converter.Convert(document);
}

// Using IronPdf (alternative)
public byte[] ConvertToPdfIron(string html)
{
    var renderer = new ChromePdfRenderer();
    var pdf = renderer.RenderHtmlAsPdf(html);
    return pdf.BinaryData;
}
```

### 5. Controller Example

```csharp
[Route("api/invoices")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;
    private readonly ITemplateService _templateService;
    
    [HttpGet("{id}/print")]
    public async Task<IActionResult> PrintInvoice(int id, [FromQuery] string template = "ModernTemplate")
    {
        var invoice = await _invoiceService.GetInvoiceForTemplate(id);
        var html = await _templateService.RenderTemplate(invoice, template);
        
        return Content(html, "text/html");
    }
    
    [HttpGet("{id}/pdf")]
    public async Task<IActionResult> DownloadPdf(int id, [FromQuery] string template = "ModernTemplate")
    {
        var invoice = await _invoiceService.GetInvoiceForTemplate(id);
        var html = await _templateService.RenderTemplate(invoice, template);
        var pdf = _templateService.ConvertToPdf(html);
        
        return File(pdf, "application/pdf", $"Invoice-{invoice.InvoiceNumber}.pdf");
    }
    
    [HttpGet("{id}/preview")]
    public async Task<IActionResult> PreviewTemplate(int id, [FromQuery] string template = "ModernTemplate")
    {
        var invoice = await _invoiceService.GetInvoiceForTemplate(id);
        var html = await _templateService.RenderTemplate(invoice, template);
        
        return Content(html, "text/html");
    }
}
```

## NuGet Packages Required

```xml
<!-- For PDF generation -->
<PackageReference Include="DinkToPdf" Version="1.0.8" />
<!-- OR -->
<PackageReference Include="IronPdf" Version="2023.x.x" />

<!-- For Razor view rendering outside of MVC -->
<PackageReference Include="Microsoft.AspNetCore.Mvc.Razor" Version="8.0.0" />
```

## Status Values

The templates support the following status values with different styling:

- **Paid** - Green badge/stamp
- **Pending** - Yellow/Amber badge/stamp  
- **Overdue** - Red badge/stamp
- **Draft** - Gray badge
- **Cancelled** - Dark badge

## File Locations

```
AccountingPro.Web/
├── Templates/
│   └── Invoices/
│       ├── ModernTemplate.cshtml      (Contemporary design)
│       ├── ClassicTemplate.cshtml     (Traditional design)
│       └── README.md                  (Documentation)
└── wwwroot/
    └── images/
        └── logo.png                   (Company logo - optional)
```

## Tips & Best Practices

1. **Testing Templates**: Use the preview endpoint before generating PDFs
2. **Performance**: Cache rendered HTML for frequently accessed invoices
3. **Customization**: Create a base template and extend for custom needs
4. **Logo**: Add company logo by setting `CompanyLogoUrl` property
5. **Multi-language**: Use resource files for template strings
6. **Branding**: Modify CSS color variables to match brand colors

## Troubleshooting

**Issue**: PDF generation fails
- **Solution**: Ensure DinkToPdf native libraries are in bin folder

**Issue**: Styles not appearing in PDF
- **Solution**: Use inline styles or embedded CSS (both templates support this)

**Issue**: Images not showing in PDF
- **Solution**: Use absolute URLs or base64-encoded images

**Issue**: Template not found
- **Solution**: Check template path and ensure file is included in project

## Need Help?

For more details, see:
- README.md - Full documentation
- InvoiceTemplateDtos.cs - DTO structure
- Template source files for styling customization
