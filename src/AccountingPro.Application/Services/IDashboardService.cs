namespace AccountingPro.Application.Services;

public interface IDashboardService
{
    Task<DashboardMetricsDto> GetDashboardMetricsAsync();
}

public class DashboardMetricsDto
{
    public decimal TotalRevenue { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal OutstandingInvoices { get; set; }
    public decimal NetProfit { get; set; }
    public int PendingInvoicesCount { get; set; }
    public int TotalInvoicesCount { get; set; }
    public int TotalCustomersCount { get; set; }
    public int TotalProductsCount { get; set; }
}
