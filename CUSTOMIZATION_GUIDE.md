# 🎨 Receipt & Invoice Design Customization Guide

This guide shows you how to customize the receipt and invoice designs in AccountingPro.

---

## 📍 Files to Customize

### 1. **Payment Receipt Design**
**Location:** `src/AccountingPro.Web/Components/Pages/PrintPaymentReceipt.razor`

This file controls the layout and design of payment receipts.

#### What You Can Customize:
- Company header layout
- Receipt title and formatting
- Payment details layout
- Amount display (size, color, formatting)
- Footer information
- Colors and fonts

#### Example Customizations:

**Change Receipt Title:**
```razor
<!-- Find this (around line 29): -->
<h3 class="mb-0">PAYMENT RECEIPT</h3>

<!-- Change to: -->
<h1 class="mb-0" style="color: #007bff;">PAYMENT RECEIPT</h1>
```

**Customize Amount Display:**
```razor
<!-- Find this (around line 88): -->
<div class="text-center mb-4">
    <h4 class="text-muted mb-1">Amount Paid</h4>
    <h1 class="display-3 mb-0">@_payment.Amount.ToString("C")</h1>
</div>

<!-- Change to add color and size: -->
<div class="text-center mb-4 p-4" style="background: #f0f8ff; border-radius: 10px;">
    <h4 class="text-primary mb-1">AMOUNT PAID</h4>
    <h1 class="display-2 mb-0 text-success fw-bold">@_payment.Amount.ToString("C")</h1>
</div>
```

**Add Company Logo:**
```razor
<!-- Add after line 16 (before company name): -->
<div class="text-center mb-4">
    <img src="/images/logo.png" alt="Company Logo" style="max-width: 200px; height: auto;" />
    <h2 class="mb-1">@_company.Name</h2>
    <!-- rest of header -->
</div>
```

---

### 2. **Invoice Design**
**Location:** `src/AccountingPro.Web/Components/Invoices.razor`

Look for the `GenerateInvoiceHtml` method (around line 1073).

#### What You Can Customize:
- Invoice header and company info
- Invoice number formatting
- Table layout for items
- Totals section formatting
- Colors and borders

#### Example Customizations:

**Add Company Logo and Styled Header:**
```csharp
private string GenerateInvoiceHtml(InvoiceDto invoice)
{
    var html = @"
        <div style='text-align: center; margin-bottom: 30px;'>
            <img src='/images/logo.png' style='max-width: 150px; height: auto;' alt='Logo' />
            <h1 style='color: #2c3e50; margin: 20px 0 5px 0;'>INVOICE</h1>
            <h2 style='color: #3498db; margin: 0;'>#" + invoice.InvoiceNumber + @"</h2>
        </div>
        <div style='background: #f8f9fa; padding: 20px; border-radius: 8px; margin-bottom: 20px;'>
            <table style='width: 100%;'>
                <tr>
                    <td style='width: 50%;'>
                        <strong style='font-size: 16px; color: #2c3e50;'>Customer:</strong><br />
                        <span style='font-size: 18px;'>" + invoice.CustomerName + @"</span>
                    </td>
                    <td style='width: 50%; text-align: right;'>
                        <strong style='font-size: 16px; color: #2c3e50;'>Invoice Date:</strong><br />
                        <span style='font-size: 18px;'>" + invoice.InvoiceDate.ToString("MMMM dd, yyyy") + @"</span>
                    </td>
                </tr>
            </table>
        </div>";

    // Continue with items table...
    if (invoice.Items != null && invoice.Items.Any())
    {
        html += @"
            <table style='width: 100%; border-collapse: collapse; margin: 20px 0;'>
                <thead>
                    <tr style='background: #3498db; color: white;'>
                        <th style='padding: 15px; text-align: left;'>Description</th>
                        <th style='padding: 15px; text-align: center;'>Qty</th>
                        <th style='padding: 15px; text-align: right;'>Unit Price</th>
                        <th style='padding: 15px; text-align: right;'>Tax Rate</th>
                        <th style='padding: 15px; text-align: right;'>Total</th>
                    </tr>
                </thead>
                <tbody>";

        foreach (var item in invoice.Items)
        {
            html += @"
                <tr style='border-bottom: 1px solid #ddd;'>
                    <td style='padding: 12px;'>" + item.Description + @"</td>
                    <td style='padding: 12px; text-align: center;'>" + item.Quantity + @"</td>
                    <td style='padding: 12px; text-align: right;'>" + item.UnitPrice.ToString("C") + @"</td>
                    <td style='padding: 12px; text-align: right;'>" + item.TaxRate.ToString("P") + @"</td>
                    <td style='padding: 12px; text-align: right; font-weight: bold;'>" + item.TotalPrice.ToString("C") + @"</td>
                </tr>";
        }

        html += "</tbody></table>";
    }

    // Totals section with styling
    html += @"
        <div style='text-align: right; margin-top: 30px; padding: 20px; background: #f8f9fa; border-radius: 8px;'>
            <p style='margin: 8px 0;'><strong>Subtotal:</strong> <span style='font-size: 18px;'>" + invoice.SubTotal.ToString("C") + @"</span></p>
            <p style='margin: 8px 0;'><strong>Tax:</strong> <span style='font-size: 18px;'>" + invoice.TaxAmount.ToString("C") + @"</span></p>
            <p style='margin: 8px 0;'><strong>Discount:</strong> <span style='font-size: 18px;'>" + invoice.DiscountAmount.ToString("C") + @"</span></p>
            <hr style='margin: 15px 0; border: 1px solid #ddd;' />
            <p style='margin: 8px 0;'><strong style='font-size: 20px; color: #2c3e50;'>TOTAL:</strong> <span style='font-size: 24px; color: #27ae60; font-weight: bold;'>" + invoice.TotalAmount.ToString("C") + @"</span></p>
            <p style='margin: 8px 0;'><strong>Paid:</strong> <span style='font-size: 18px; color: #3498db;'>" + invoice.PaidAmount.ToString("C") + @"</span></p>
            <p style='margin: 8px 0;'><strong style='color: #e74c3c;'>Balance Due:</strong> <span style='font-size: 20px; color: #e74c3c; font-weight: bold;'>" + invoice.BalanceAmount.ToString("C") + @"</span></p>
        </div>";

    if (!string.IsNullOrEmpty(invoice.Notes))
    {
        html += @"
            <div style='margin-top: 30px; padding: 15px; background: #fff3cd; border-left: 4px solid #ffc107; border-radius: 4px;'>
                <strong style='color: #856404;'>Notes:</strong><br />
                <p style='margin: 10px 0 0 0; color: #856404;'>" + invoice.Notes + @"</p>
            </div>";
    }

    return html;
}
```

---

### 3. **Print Stylesheet**
**Location:** `src/AccountingPro.Web/wwwroot/css/app.css`

Find the `@media print` section (around line 752) to customize print-specific styles.

#### Example Customizations:

**Add Page Margins:**
```css
@media print {
    @page {
        margin: 1cm;
        size: A4;
    }
    
    /* Add watermark */
    body::before {
        content: "PAID";
        position: fixed;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%) rotate(-45deg);
        font-size: 120px;
        color: rgba(0, 255, 0, 0.1);
        font-weight: bold;
        z-index: -1;
    }
    
    /* Hide non-printable elements */
    .sidebar,
    .top-row,
    .no-print,
    nav,
    button,
    .btn {
        display: none !important;
    }
}
```

---

## 🎨 Color Schemes

### Professional Blue Theme:
```css
Primary: #2c3e50
Secondary: #3498db
Success: #27ae60
Warning: #f39c12
Danger: #e74c3c
```

### Modern Green Theme:
```css
Primary: #1e8449
Secondary: #58d68d
Success: #2ecc71
Warning: #f4d03f
Danger: #e74c3c
```

### Corporate Purple Theme:
```css
Primary: #6c3483
Secondary: #a569bd
Success: #27ae60
Warning: #f39c12
Danger: #e74c3c
```

---

## 📝 Common Customization Tasks

### 1. Change Fonts
Add to your print stylesheet:
```css
@media print {
    * {
        font-family: 'Arial', 'Helvetica', sans-serif;
    }
    
    h1, h2, h3 {
        font-family: 'Georgia', 'Times New Roman', serif;
    }
}
```

### 2. Add Terms & Conditions
In `PrintPaymentReceipt.razor`, add before closing `</div>`:
```razor
<!-- Terms and Conditions -->
<div class="mt-5 pt-4 border-top">
    <h6 class="text-muted">Terms & Conditions</h6>
    <small class="text-muted">
        <ul class="mb-0" style="font-size: 0.8rem;">
            <li>All payments are non-refundable</li>
            <li>Please retain this receipt for your records</li>
            <li>For queries, contact us within 7 days</li>
        </ul>
    </small>
</div>
```

### 3. Add QR Code (for payment verification)
```razor
<!-- Add in receipt -->
<div class="text-center mt-4">
    <img src="https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=Receipt-@_payment.PaymentNumber" 
         alt="QR Code" 
         style="width: 150px; height: 150px;" />
    <p class="text-muted small">Scan to verify</p>
</div>
```

### 4. Add Signature Line
```razor
<!-- Add before closing receipt wrapper -->
<div class="mt-5 pt-4">
    <div class="row">
        <div class="col-6">
            <div style="border-top: 1px solid #000; padding-top: 10px; margin-top: 50px;">
                <small>Received By</small>
            </div>
        </div>
        <div class="col-6">
            <div style="border-top: 1px solid #000; padding-top: 10px; margin-top: 50px;">
                <small>Authorized Signature</small>
            </div>
        </div>
    </div>
</div>
```

---

## 🖼️ Adding Company Logo

1. **Add your logo file** to: `src/AccountingPro.Web/wwwroot/images/logo.png`

2. **Update the receipt** to include logo:
```razor
<div class="text-center mb-4">
    <img src="/images/logo.png" alt="@_company.Name Logo" 
         style="max-width: 200px; height: auto; margin-bottom: 20px;" />
    <h2 class="mb-1">@_company.Name</h2>
    <!-- rest of company info -->
</div>
```

---

## 💡 Tips

1. **Test in Print Preview** - Always test your changes using browser print preview (Ctrl+P)
2. **Use Inline Styles** - For invoice HTML generation, use inline styles for better compatibility
3. **Keep it Simple** - Simpler designs print more reliably across different browsers
4. **Consider Paper Size** - Design for A4 (210mm × 297mm) or Letter (8.5" × 11")
5. **Avoid Heavy Graphics** - Large images can slow down printing
6. **Use Web-Safe Fonts** - Arial, Helvetica, Times New Roman, Georgia

---

## 🔧 Testing Your Changes

1. Make your changes to the files
2. Rebuild the project: `dotnet build`
3. Run the application: `dotnet run`
4. Create a test payment or invoice
5. Click "Print" button
6. Use browser print preview to see results

---

## 📞 Need Help?

- Check Bootstrap documentation for styling: https://getbootstrap.com
- CSS print tips: https://www.smashingmagazine.com/2018/05/print-stylesheets-in-2018/
- Blazor component docs: https://learn.microsoft.com/aspnet/core/blazor/

---

**Happy Customizing! 🎨**
