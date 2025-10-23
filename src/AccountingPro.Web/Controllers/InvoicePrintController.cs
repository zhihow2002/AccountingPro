using AccountingPro.Application.DTOs;
using AccountingPro.Application.Services;
using AccountingPro.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingPro.Web.Controllers;

[Route("api/invoices/print")]
[ApiController]
public class InvoicePrintController : ControllerBase
{
    private const string DefaultTemplate = "ModernTemplate";
    private const string ModernTemplateName = "ModernTemplate";
    private const string ClassicTemplateName = "ClassicTemplate";
    
    private readonly IInvoiceTemplateService _templateService;
    private readonly IInvoicePrintService _printService;
    // Note: Replace mock data methods with actual repository injections when ready
    
    public InvoicePrintController(
        IInvoiceTemplateService templateService,
        IInvoicePrintService printService)
    {
        _templateService = templateService;
        _printService = printService;
    }
    
    /// <summary>
    /// Preview invoice in browser using company's default template
    /// GET: api/invoices/print/123/preview
    /// </summary>
    [HttpGet("{invoiceId}/preview")]
    [Produces("text/html")]
    public async Task<IActionResult> PreviewInvoice(int invoiceId)
    {
        try
        {
            // Note: Using mock data - replace with actual service calls
            var invoice = GetMockInvoiceDto(invoiceId);
            var company = GetMockCompanyDto();
            var customer = GetMockCustomerDto();
            
            var printDto = _printService.MapToPrintDto(invoice, company, customer);
            
            // Use company's preferred template (from company.InvoiceTemplateName)
            var templateName = company.Name.Contains("Tech") ? ModernTemplateName : ClassicTemplateName;
            
            var html = await _templateService.RenderInvoiceHtmlAsync(printDto, templateName);
            
            return Content(html, "text/html");
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
    
    /// <summary>
    /// Preview invoice with specific template
    /// GET: api/invoices/print/123/preview?template=ClassicTemplate
    /// </summary>
    [HttpGet("{invoiceId}/preview-template")]
    [Produces("text/html")]
    public async Task<IActionResult> PreviewInvoiceWithTemplate(
        int invoiceId, 
        [FromQuery] string template = DefaultTemplate)
    {
        try
        {
            var availableTemplates = _templateService.GetAvailableTemplates();
            if (!availableTemplates.Contains(template))
            {
                return BadRequest(new 
                { 
                    error = $"Template '{template}' not found",
                    availableTemplates 
                });
            }
            
            // Note: Using mock data - replace with actual service calls
            var invoice = GetMockInvoiceDto(invoiceId);
            var company = GetMockCompanyDto();
            var customer = GetMockCustomerDto();
            
            var printDto = _printService.MapToPrintDto(invoice, company, customer);
            var html = await _templateService.RenderInvoiceHtmlAsync(printDto, template);
            
            return Content(html, "text/html");
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
    
    /// <summary>
    /// Download invoice as PDF
    /// GET: api/invoices/print/123/pdf
    /// </summary>
    [HttpGet("{invoiceId}/pdf")]
    [Produces("application/pdf")]
    public Task<IActionResult> DownloadInvoicePdf(int invoiceId)
    {
        try
        {
            // Note: PDF generation requires DinkToPdf implementation
            // When implemented, this will:
            // 1. Get invoice, company, customer data from repositories
            // 2. Map to InvoicePrintDto using _printService.MapToPrintDto()
            // 3. Use company.InvoiceTemplateName for template selection
            // 4. Render HTML using _templateService.RenderInvoiceHtmlAsync()
            // 5. Convert HTML to PDF using DinkToPdf
            // See TEMPLATE_SELECTION_GUIDE.md for complete implementation steps
            
            return Task.FromResult<IActionResult>(Content($"PDF download for invoice {invoiceId} not yet implemented. Install DinkToPdf and implement ConvertToPdf method.", "text/plain"));
        }
        catch (Exception ex)
        {
            return Task.FromResult<IActionResult>(StatusCode(500, new { error = ex.Message }));
        }
    }
    
    /// <summary>
    /// Get available templates
    /// GET: api/invoices/print/templates
    /// </summary>
    [HttpGet("templates")]
    public IActionResult GetAvailableTemplates()
    {
        var templates = _templateService.GetAvailableTemplates();
        return Ok(new 
        { 
            templates,
            descriptions = new Dictionary<string, string>
            {
                { "ModernTemplate", "Contemporary design with blue color scheme - ideal for tech companies" },
                { "ClassicTemplate", "Traditional formal design with black & white - ideal for professional services" }
            }
        });
    }
    
    
    // MOCK DATA METHODS - Replace these with actual service calls
    
    private InvoiceDto GetMockInvoiceDto(int id)
    {
        return new InvoiceDto
        {
            Id = id,
            InvoiceNumber = $"INV-{DateTime.Now:yyyy}-{id:D4}",
            CustomerId = 1,
            CustomerName = "John Smith",
            InvoiceDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(30),
            SubTotal = 1000.00m,
            TaxAmount = 80.00m,
            DiscountAmount = 50.00m,
            TotalAmount = 1030.00m,
            PaidAmount = 0.00m,
            OutstandingAmount = 1030.00m,
            BalanceAmount = 1030.00m,
            Description = "Professional services rendered",
            Status = Core.Enums.InvoiceStatus.Sent,
            Notes = "Thank you for your business!",
            CreatedAt = DateTime.Now,
            Items = new List<InvoiceItemDto>
            {
                new()
                {
                    Id = 1,
                    ProductId = 1,
                    ProductName = "Consulting Services",
                    Description = "Software development consulting",
                    Quantity = 10,
                    UnitPrice = 100.00m,
                    TaxRate = 8.00m,
                    LineTotal = 1000.00m,
                    TotalPrice = 1080.00m
                }
            }
        };
    }
    
    private CompanyDto GetMockCompanyDto()
    {
        return new CompanyDto
        {
            Id = 1,
            Name = "Acme Corporation",
            Code = "ACME01",
            Address = "123 Business Street, Suite 100, Business City, BC 12345",
            Phone = "+1 (555) 123-4567",
            Email = "billing@acmecorp.com",
            TaxId = "TAX-123456789",
            IsActive = true
        };
    }
    
    private CustomerDto GetMockCustomerDto()
    {
        return new CustomerDto
        {
            Id = 1,
            Name = "John Smith",
            CompanyName = "Smith Enterprises Ltd.",
            Email = "john@smithent.com",
            Phone = "+1 (555) 987-6543",
            Address = "456 Client Avenue",
            City = "New York",
            State = "NY",
            ZipCode = "10001",
            Country = "United States",
            Status = Core.Enums.CustomerStatus.Active
        };
    }
}
