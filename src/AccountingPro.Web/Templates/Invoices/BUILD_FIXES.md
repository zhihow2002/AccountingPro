# Invoice Template Build Fixes

## Summary
Successfully fixed all compilation errors in the invoice template system. Build now completes successfully with only pre-existing warnings.

## Issues Fixed

### 1. DTO Structure Mismatch
**Problem:** Templates were using `InvoiceTemplateDto` but referencing properties from the existing `InvoiceDto` class.

**Solution:** 
- Created `InvoicePrintDto` class that extends `InvoiceDto`
- Added company and customer detail properties
- Removed duplicate properties that already exist in base `InvoiceDto`

**File Changed:** `src/AccountingPro.Application/DTOs/InvoiceTemplateDtos.cs`

```csharp
public class InvoicePrintDto : InvoiceDto
{
    // Company Information
    public string CompanyName { get; set; } = string.Empty;
    public string CompanyAddress { get; set; } = string.Empty;
    public string CompanyPhone { get; set; } = string.Empty;
    public string CompanyEmail { get; set; } = string.Empty;
    public string? CompanyTaxId { get; set; }
    public string? CompanyLogoUrl { get; set; }
    
    // Extended Customer Information
    public string? CustomerCompany { get; set; }
    public string? CustomerAddress { get; set; }
    public string? CustomerCity { get; set; }
    public string? CustomerState { get; set; }
    public string? CustomerZipCode { get; set; }
    public string? CustomerCountry { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerPhone { get; set; }
    
    // Payment terms
    public string? Terms { get; set; }
}
```

### 2. Model Declaration Updates
**Problem:** Templates were using `@model InvoiceDto` but needed `InvoicePrintDto`.

**Solution:** Updated both template files to use the correct model and import the enums namespace.

**Files Changed:**
- `ModernTemplate.cshtml`
- `ClassicTemplate.cshtml`

```cshtml
@using AccountingPro.Core.Enums
@model AccountingPro.Application.DTOs.InvoicePrintDto
```

### 3. Enum Comparison Errors
**Problem:** Status comparisons like `Model.Status == "Paid"` were comparing enum to string.

**Solution:** Changed to proper enum comparisons using `InvoiceStatus` enum.

**Before:**
```cshtml
@if (Model.Status == "Paid")
```

**After:**
```cshtml
@if (Model.Status == InvoiceStatus.Paid)
```

### 4. Missing Properties in InvoiceItemDto
**Problem:** Templates were trying to access `TaxAmount` and `Discount` properties that don't exist in `InvoiceItemDto`.

**Available Properties:**
- `InvoiceItemDto.TaxRate` (not TaxAmount)
- No Discount property (discount is at invoice level)

**Solution:** Calculate values on the fly in the templates.

**Before:**
```cshtml
<td>@item.TaxAmount.ToString("C")</td>
<td>@(item.Discount > 0 ? item.Discount.ToString("C") : "-")</td>
```

**After:**
```cshtml
var taxAmount = item.UnitPrice * item.Quantity * item.TaxRate / 100;
var discountAmount = Model.DiscountAmount > 0 ? (Model.DiscountAmount / Model.Items.Count) : 0;
<td>@taxAmount.ToString("C")</td>
<td>@(discountAmount > 0 ? discountAmount.ToString("C") : "-")</td>
```

## Build Result
✅ **Build Succeeded** - All compilation errors resolved
- 0 build errors
- Only package vulnerability warnings (pre-existing)
- Only async method warnings in other Razor files (pre-existing)

## Template Status
Both invoice templates are now ready to use:
- ✅ `ModernTemplate.cshtml` - Compiles successfully
- ✅ `ClassicTemplate.cshtml` - Compiles successfully (1 cosmetic HTML lint warning about missing `<th>` in totals table)

## Next Steps
To use these templates in your application:

1. **Create a mapping service** to convert `InvoiceDto` + `CompanyDto` + `CustomerDto` → `InvoicePrintDto`
2. **Implement template rendering** using Razor view engine or similar
3. **Add PDF generation** using DinkToPdf or IronPdf
4. **Create controller endpoints** for print and PDF export functionality

Example mapping:
```csharp
public InvoicePrintDto MapToPrintDto(InvoiceDto invoice, CompanyDto company, CustomerDto customer)
{
    return new InvoicePrintDto
    {
        // Copy all InvoiceDto properties
        Id = invoice.Id,
        InvoiceNumber = invoice.InvoiceNumber,
        Status = invoice.Status,
        // ... all other invoice properties
        
        // Add company details
        CompanyName = company.Name,
        CompanyAddress = company.Address,
        CompanyPhone = company.Phone,
        CompanyEmail = company.Email,
        CompanyTaxId = company.TaxId,
        
        // Add customer details
        CustomerCompany = customer.CompanyName,
        CustomerAddress = customer.Address,
        CustomerCity = customer.City,
        CustomerState = customer.State,
        CustomerZipCode = customer.ZipCode,
        CustomerCountry = customer.Country,
        CustomerEmail = customer.Email,
        CustomerPhone = customer.Phone,
        
        // Add terms
        Terms = "Net 30 Days" // or from configuration
    };
}
```

## Files Modified
1. `src/AccountingPro.Application/DTOs/InvoiceTemplateDtos.cs` - Complete rewrite
2. `src/AccountingPro.Web/Templates/Invoices/ModernTemplate.cshtml` - Fixed model, status comparisons, item calculations
3. `src/AccountingPro.Web/Templates/Invoices/ClassicTemplate.cshtml` - Fixed model, status comparisons, item calculations

## Testing Checklist
- [x] Project builds successfully
- [ ] Templates render with sample data
- [ ] PDF generation works
- [ ] Print layout displays correctly
- [ ] All invoice statuses display properly
- [ ] Tax calculations are correct
- [ ] Discount display is correct
