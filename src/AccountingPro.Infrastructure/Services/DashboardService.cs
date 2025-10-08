namespace AccountingPro.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IInvoiceService _invoiceService;
    private readonly IBillService _billService;
    private readonly ICustomerService _customerService;
    private readonly IProductService _productService;

    public DashboardService(
        IInvoiceService invoiceService,
        IBillService billService,
        ICustomerService customerService,
        IProductService productService)
    {
        _invoiceService = invoiceService;
        _billService = billService;
        _customerService = customerService;
        _productService = productService;
    }

    public async Task<DashboardMetricsDto> GetDashboardMetricsAsync()
    {
        // Get current month date range
        var now = DateTime.Now;
        var startOfMonth = new DateTime(now.Year, now.Month, 1, 0, 0, 0, DateTimeKind.Local);
        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

        // Get all invoices and bills
        var invoices = await _invoiceService.GetAllInvoicesAsync();
        var bills = await _billService.GetAllBillsAsync();
        var customers = await _customerService.GetAllCustomersAsync();
        var products = await _productService.GetAllProductsAsync();

        // Calculate metrics
        var monthlyInvoices = invoices.Where(i => i.InvoiceDate >= startOfMonth && i.InvoiceDate <= endOfMonth);
        var monthlyBills = bills.Where(b => b.BillDate >= startOfMonth && b.BillDate <= endOfMonth);

        var totalRevenue = monthlyInvoices.Sum(i => i.TotalAmount);
        var totalExpenses = monthlyBills.Sum(b => b.TotalAmount);
        var outstandingInvoices = invoices.Where(i => i.BalanceAmount > 0).Sum(i => i.BalanceAmount);
        var netProfit = totalRevenue - totalExpenses;

        var pendingInvoicesCount = invoices.Count(i => i.Status == Core.Enums.InvoiceStatus.Sent || i.Status == Core.Enums.InvoiceStatus.PartiallyPaid);

        return new DashboardMetricsDto
        {
            TotalRevenue = totalRevenue,
            TotalExpenses = totalExpenses,
            OutstandingInvoices = outstandingInvoices,
            NetProfit = netProfit,
            PendingInvoicesCount = pendingInvoicesCount,
            TotalInvoicesCount = invoices.Count,
            TotalCustomersCount = customers.Count,
            TotalProductsCount = products.Count
        };
    }
}