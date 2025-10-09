using AccountingPro.Core.Enums;

namespace AccountingPro.Application.DTOs;

public class PaymentDto
{
    public int Id { get; set; }
    public string PaymentNumber { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus Status { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    
    // Optional foreign keys
    public int? CustomerId { get; set; }
    public int? SupplierId { get; set; }
    public int? InvoiceId { get; set; }
    public int? BillId { get; set; }
    public int? BankAccountId { get; set; }
    
    // Display properties
    public string CustomerName { get; set; } = string.Empty;
    public string InvoiceNumber { get; set; } = string.Empty;
}

public class CreatePaymentReceiptDto
{
    public DateTime PaymentDate { get; set; } = DateTime.Today;
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; } = PaymentMethod.Cash;
    public string Reference { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    
    public int? CustomerId { get; set; }
    public int? InvoiceId { get; set; }
    public int? BankAccountId { get; set; }
}

public class CashSaleDto
{
    public DateTime SaleDate { get; set; } = DateTime.Today;
    public int? CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public List<CashSaleItemDto> Items { get; set; } = new();
    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public PaymentMethod Method { get; set; } = PaymentMethod.Cash;
    public string Reference { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}

public class CashSaleItemDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; } = 1;
    public decimal UnitPrice { get; set; }
    public decimal TaxRate { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal LineTotal { get; set; }
}
