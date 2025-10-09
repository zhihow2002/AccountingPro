using AccountingPro.Application.DTOs;

namespace AccountingPro.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IInvoiceService _invoiceService;
    private readonly IBillService _billService;
    private readonly ICustomerService _customerService;
    private readonly IProductService _productService;
    private readonly ICompanyContextService _companyContext;

    public DashboardService(
        IInvoiceService invoiceService,
        IBillService billService,
        ICustomerService customerService,
        IProductService productService,
        ICompanyContextService companyContext
    )
    {
        _invoiceService = invoiceService;
        _billService = billService;
        _customerService = customerService;
        _productService = productService;
        _companyContext = companyContext;
    }

    public async Task<DashboardMetricsDto> GetDashboardMetricsAsync()
    {
        try
        {
            // Ensure company context is initialized
            await _companyContext.InitializeAsync();

            if (_companyContext.CurrentCompanyId == null)
            {
                // Return empty metrics if no company is selected
                return new DashboardMetricsDto();
            }

            // Get current month date range
            var now = DateTime.Now;
            var startOfMonth = new DateTime(now.Year, now.Month, 1, 0, 0, 0, DateTimeKind.Local);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            // Get all invoices and bills - wrap in try-catch for graceful fallback
            List<InvoiceDto> invoices = new();
            List<BillDto> bills = new();
            List<CustomerDto> customers = new();
            List<ProductDto> products = new();

            try
            {
                invoices = await _invoiceService.GetAllInvoicesAsync() ?? new List<InvoiceDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading invoices for dashboard: {ex.Message}");
            }

            try
            {
                bills = await _billService.GetAllBillsAsync() ?? new List<BillDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading bills for dashboard: {ex.Message}");
            }

            try
            {
                customers =
                    await _customerService.GetAllCustomersAsync() ?? new List<CustomerDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading customers for dashboard: {ex.Message}");
            }

            try
            {
                products = await _productService.GetAllProductsAsync() ?? new List<ProductDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading products for dashboard: {ex.Message}");
            }

            // Calculate metrics
            var monthlyInvoices = invoices.Where(
                i => i.InvoiceDate >= startOfMonth && i.InvoiceDate <= endOfMonth
            );
            var monthlyBills = bills.Where(
                b => b.BillDate >= startOfMonth && b.BillDate <= endOfMonth
            );

            var totalRevenue = monthlyInvoices.Sum(i => i.TotalAmount);
            var totalExpenses = monthlyBills.Sum(b => b.TotalAmount);
            var outstandingInvoices = invoices
                .Where(i => i.BalanceAmount > 0)
                .Sum(i => i.BalanceAmount);
            var netProfit = totalRevenue - totalExpenses;

            var pendingInvoicesCount = invoices.Count(
                i =>
                    i.Status == Core.Enums.InvoiceStatus.Sent
                    || i.Status == Core.Enums.InvoiceStatus.PartiallyPaid
            );

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
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetDashboardMetricsAsync: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");

            // Return empty metrics on error
            return new DashboardMetricsDto();
        }
    }
}
