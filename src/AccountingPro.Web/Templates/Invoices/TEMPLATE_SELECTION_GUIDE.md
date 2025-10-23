# Invoice Template Selection by Company

## Overview
This guide explains how to configure and use different invoice templates for different companies in AccountingPro.

## System Architecture

```
┌─────────────────────────────────────────────────────────────────┐
│                         Company Entity                           │
│  - InvoiceTemplateName: "ModernTemplate" or "ClassicTemplate"   │
│  - LogoUrl: Optional company logo                                │
└─────────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                    InvoicePrintService                           │
│  Maps: Invoice + Company + Customer → InvoicePrintDto           │
└─────────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                  InvoiceTemplateService                          │
│  Renders: InvoicePrintDto + TemplateName → HTML                 │
└─────────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                    Invoice Templates                             │
│  - ModernTemplate.cshtml (Blue, contemporary)                    │
│  - ClassicTemplate.cshtml (B&W, formal)                          │
└─────────────────────────────────────────────────────────────────┘
```

## Database Changes Required

### 1. Add Migration for Company Entity

The `Company` entity now has two new properties:

```csharp
public class Company : BaseEntity
{
    // ... existing properties ...
    
    // NEW PROPERTIES
    public string InvoiceTemplateName { get; set; } = "ModernTemplate";
    public string? LogoUrl { get; set; }
}
```

**Run migration:**
```powershell
cd E:\Code\AccountingPro\src\AccountingPro.Infrastructure
dotnet ef migrations add AddInvoiceTemplateToCompany -s ..\AccountingPro.Web
dotnet ef database update -s ..\AccountingPro.Web
```

## Configuration

### 1. Register Services in Program.cs

Add these services to your `Program.cs` in AccountingPro.Web:

```csharp
// Add Razor View Engine for template rendering
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Register invoice services
builder.Services.AddScoped<IInvoicePrintService, InvoicePrintService>();
builder.Services.AddScoped<IInvoiceTemplateService, InvoiceTemplateService>();
```

### 2. Set Company Template Preference

#### Option A: Via Database (Recommended)
Update company settings in your database or through admin UI:

```sql
-- Set Modern template for tech companies
UPDATE Companies 
SET InvoiceTemplateName = 'ModernTemplate'
WHERE Name LIKE '%Tech%' OR Name LIKE '%Software%';

-- Set Classic template for law firms
UPDATE Companies 
SET InvoiceTemplateName = 'ClassicTemplate'
WHERE Name LIKE '%Law%' OR Name LIKE '%Legal%';
```

#### Option B: Via API
Create an endpoint to update company settings:

```csharp
[HttpPut("api/companies/{id}/invoice-template")]
public async Task<IActionResult> UpdateInvoiceTemplate(int id, [FromBody] string templateName)
{
    var company = await _companyRepository.GetByIdAsync(id);
    if (company == null) return NotFound();
    
    var availableTemplates = new[] { "ModernTemplate", "ClassicTemplate" };
    if (!availableTemplates.Contains(templateName))
        return BadRequest("Invalid template name");
    
    company.InvoiceTemplateName = templateName;
    await _companyRepository.UpdateAsync(company);
    
    return Ok();
}
```

## Usage Examples

### 1. Preview Invoice in Browser

Navigate to:
```
http://localhost:5000/api/invoices/print/123/preview
```

This will:
1. Load invoice #123
2. Get company settings (including template preference)
3. Render using company's preferred template
4. Display HTML in browser

### 2. Preview with Specific Template

Test different templates:
```
http://localhost:5000/api/invoices/print/123/preview-template?template=ModernTemplate
http://localhost:5000/api/invoices/print/123/preview-template?template=ClassicTemplate
```

### 3. Get Available Templates

```
GET http://localhost:5000/api/invoices/print/templates
```

Response:
```json
{
  "templates": ["ModernTemplate", "ClassicTemplate"],
  "descriptions": {
    "ModernTemplate": "Contemporary design with blue color scheme - ideal for tech companies",
    "ClassicTemplate": "Traditional formal design with black & white - ideal for professional services"
  }
}
```

### 4. Download Invoice as PDF

```
GET http://localhost:5000/api/invoices/print/123/pdf
```

Note: PDF generation requires DinkToPdf implementation (see below).

## Template Selection Logic

### Automatic Selection (Recommended)

The system automatically selects the template based on company settings:

```csharp
// In your invoice service
public async Task<string> GenerateInvoiceHtml(int invoiceId)
{
    var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
    var company = await _companyRepository.GetByIdAsync(invoice.CompanyId);
    var customer = await _customerRepository.GetByIdAsync(invoice.CustomerId);
    
    var printDto = _printService.MapToPrintDto(invoice, company, customer);
    
    // Use company's preferred template
    var templateName = company.InvoiceTemplateName ?? "ModernTemplate";
    
    return await _templateService.RenderInvoiceHtmlAsync(printDto, templateName);
}
```

### Manual Override

Allow users to override the template:

```csharp
[HttpGet("{invoiceId}/print")]
public async Task<IActionResult> PrintInvoice(
    int invoiceId, 
    [FromQuery] string? template = null)
{
    var invoice = await GetInvoice(invoiceId);
    var company = await GetCompany(invoice.CompanyId);
    
    // Use specified template or fall back to company default
    var templateName = template ?? company.InvoiceTemplateName ?? "ModernTemplate";
    
    // ... render and return
}
```

## Adding New Templates

### 1. Create Template File

Create new `.cshtml` file in `Templates/Invoices/`:

```
AccountingPro.Web/
  Templates/
    Invoices/
      ModernTemplate.cshtml
      ClassicTemplate.cshtml
      YourNewTemplate.cshtml    ← Add here
```

### 2. Register Template

Update `InvoiceTemplateService.cs`:

```csharp
public List<string> GetAvailableTemplates()
{
    return new List<string>
    {
        "ModernTemplate",
        "ClassicTemplate",
        "YourNewTemplate"    // Add here
    };
}
```

### 3. Update Enum (Optional)

Update `InvoiceTemplate` enum in `AccountingEnums.cs`:

```csharp
public enum InvoiceTemplate
{
    ModernTemplate = 1,
    ClassicTemplate = 2,
    YourNewTemplate = 3    // Add here
}
```

## PDF Generation Setup

### Install DinkToPdf

```powershell
cd E:\Code\AccountingPro\src\AccountingPro.Web
dotnet add package DinkToPdf
```

### Add Native Libraries

Download and extract native libraries:
- Windows: `libwkhtmltox.dll`
- Linux: `libwkhtmltox.so`
- Mac: `libwkhtmltox.dylib`

Place in: `AccountingPro.Web/wwwroot/lib/wkhtmltox/`

### Implement PDF Service

Create `PdfService.cs`:

```csharp
using DinkToPdf;
using DinkToPdf.Contracts;

public interface IPdfService
{
    byte[] ConvertHtmlToPdf(string html);
}

public class PdfService : IPdfService
{
    private readonly IConverter _converter;
    
    public PdfService(IConverter converter)
    {
        _converter = converter;
    }
    
    public byte[] ConvertHtmlToPdf(string html)
    {
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
        
        return _converter.Convert(document);
    }
}
```

### Register PDF Service

In `Program.cs`:

```csharp
// Register DinkToPdf
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<IPdfService, PdfService>();
```

### Update Controller

```csharp
[HttpGet("{invoiceId}/pdf")]
public async Task<IActionResult> DownloadInvoicePdf(int invoiceId)
{
    var invoice = await GetInvoice(invoiceId);
    var company = await GetCompany(invoice.CompanyId);
    var customer = await GetCustomer(invoice.CustomerId);
    
    var printDto = _printService.MapToPrintDto(invoice, company, customer);
    var templateName = company.InvoiceTemplateName ?? "ModernTemplate";
    
    var html = await _templateService.RenderInvoiceHtmlAsync(printDto, templateName);
    var pdfBytes = _pdfService.ConvertHtmlToPdf(html);
    
    return File(pdfBytes, "application/pdf", $"Invoice-{invoice.InvoiceNumber}.pdf");
}
```

## Template Selection UI

### Admin Settings Page

Create a company settings page where admins can select templates:

```html
<div class="form-group">
    <label>Invoice Template</label>
    <select name="invoiceTemplate" class="form-control">
        <option value="ModernTemplate">Modern (Blue, Contemporary)</option>
        <option value="ClassicTemplate">Classic (Black & White, Formal)</option>
    </select>
</div>

<div class="template-preview">
    <img src="/images/templates/modern-preview.png" />
    <img src="/images/templates/classic-preview.png" />
</div>
```

### User Invoice Actions

Add template selection when viewing invoices:

```html
<div class="invoice-actions">
    <button onclick="printInvoice('ModernTemplate')">Print (Modern)</button>
    <button onclick="printInvoice('ClassicTemplate')">Print (Classic)</button>
    <button onclick="downloadPdf()">Download PDF</button>
</div>

<script>
function printInvoice(template) {
    window.open(`/api/invoices/print/${invoiceId}/preview-template?template=${template}`, '_blank');
}

function downloadPdf() {
    window.location.href = `/api/invoices/print/${invoiceId}/pdf`;
}
</script>
```

## Testing

### 1. Test Template Rendering

```powershell
# Preview invoice with default template
curl http://localhost:5000/api/invoices/print/1/preview

# Preview with specific template
curl http://localhost:5000/api/invoices/print/1/preview-template?template=ClassicTemplate

# Get available templates
curl http://localhost:5000/api/invoices/print/templates
```

### 2. Test Different Companies

```csharp
// Create test companies with different templates
var techCompany = new Company 
{ 
    Name = "Tech Innovations Inc.",
    InvoiceTemplateName = "ModernTemplate"
};

var lawFirm = new Company 
{ 
    Name = "Smith & Associates Law",
    InvoiceTemplateName = "ClassicTemplate"
};
```

## Troubleshooting

### Template Not Found Error

```
Template 'ModernTemplate' not found. Searched locations: ...
```

**Solution:** Ensure template files are in correct location and marked as content files:
```xml
<ItemGroup>
  <Content Include="Templates\Invoices\*.cshtml">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </Content>
</ItemGroup>
```

### Company Template Not Updating

**Solution:** Clear cache and ensure database migration was applied:
```powershell
dotnet ef database update -s ..\AccountingPro.Web
```

### PDF Generation Fails

**Solution:** 
1. Verify native libraries are in correct location
2. Check file permissions
3. Ensure DinkToPdf is registered correctly in DI container

## Best Practices

1. **Default Template**: Always set a default template in case company setting is null
2. **Template Validation**: Validate template names before rendering
3. **Caching**: Consider caching rendered HTML for frequently accessed invoices
4. **Logging**: Log template selection and rendering errors
5. **Testing**: Test both templates with various invoice scenarios
6. **Performance**: Render templates asynchronously for better performance

## Summary

To select which template to use by company:

1. ✅ Add `InvoiceTemplateName` to Company entity (Done)
2. ✅ Create `InvoiceTemplate` enum (Done)
3. ✅ Create services for template rendering (Done)
4. ✅ Create controller endpoints (Done)
5. ⏳ Run database migration (Next step)
6. ⏳ Register services in Program.cs (Next step)
7. ⏳ Update company records with template preferences (Next step)
8. ⏳ Implement PDF generation (Optional)

The system now supports per-company template selection with easy extensibility for adding new templates!
