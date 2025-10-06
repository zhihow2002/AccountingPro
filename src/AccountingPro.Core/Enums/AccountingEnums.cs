namespace AccountingPro.Core.Enums;

public enum AccountType
{
    Asset = 1,
    Liability = 2,
    Equity = 3,
    Revenue = 4,
    Expense = 5
}

public enum JournalEntryStatus
{
    Draft = 1,
    Pending = 2,
    Approved = 3,
    Rejected = 4,
    Reversed = 5
}

public enum TransactionType
{
    Debit = 1,
    Credit = 2
}

public enum FiscalYearStatus
{
    Open = 1,
    Closed = 2
}

public enum AccountingPeriodStatus
{
    Open = 1,
    Closed = 2,
    Locked = 3
}

public enum CustomerStatus
{
    Active = 1,
    Inactive = 2,
    Blocked = 3
}

public enum SupplierStatus
{
    Active = 1,
    Inactive = 2,
    Blocked = 3
}

public enum InvoiceStatus
{
    Draft = 1,
    Sent = 2,
    Paid = 3,
    PartiallyPaid = 4,
    Overdue = 5,
    Cancelled = 6,
    Refunded = 7
}

public enum BillStatus
{
    Draft = 1,
    Received = 2,
    Paid = 3,
    PartiallyPaid = 4,
    Overdue = 5,
    Cancelled = 6
}

public enum PaymentStatus
{
    Pending = 1,
    Completed = 2,
    Failed = 3,
    Cancelled = 4,
    Refunded = 5
}

public enum PaymentMethod
{
    Cash = 1,
    Check = 2,
    CreditCard = 3,
    BankTransfer = 4,
    PayPal = 5,
    Other = 6
}

public enum TaxType
{
    SalesTax = 1,
    VAT = 2,
    GST = 3,
    ServiceTax = 4,
    Other = 5
}

public enum DocumentType
{
    Invoice = 1,
    Bill = 2,
    Payment = 3,
    Receipt = 4,
    JournalEntry = 5,
    PurchaseOrder = 6,
    Quotation = 7
}