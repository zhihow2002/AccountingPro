using AccountingPro.Core.Entities;
using AccountingPro.Core.Enums;
using AccountingPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Data;

public static class DataSeeder
{
    public static async Task SeedDataAsync(AccountingDbContext context)
    {
        if (!await context.Companies.AnyAsync())
        {
            await SeedCompaniesAsync(context);
        }

        if (!await context.Accounts.AnyAsync())
        {
            await SeedAccountsAsync(context);
        }

        if (!await context.FiscalYears.AnyAsync())
        {
            await SeedFiscalYearsAsync(context);
        }

        if (!await context.AccountingPeriods.AnyAsync())
        {
            await SeedAccountingPeriodsAsync(context);
        }

        await context.SaveChangesAsync();
    }

    private static async Task SeedCompaniesAsync(AccountingDbContext context)
    {
        var company = new Company
        {
            Code = "DEMO001",
            Name = "Demo Accounting Company",
            Address = "123 Business Street, Business City, BC 12345",
            Phone = "+1 (555) 123-4567",
            Email = "info@demoacc.com",
            TaxId = "123456789",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        context.Companies.Add(company);
        await context.SaveChangesAsync();
    }

    private static async Task SeedAccountsAsync(AccountingDbContext context)
    {
        var company = await context.Companies.FirstAsync();
        
        var accounts = new List<Account>
        {
            // Assets
            new Account
            {
                Code = "1100",
                Name = "Cash",
                AccountType = AccountType.Asset,
                Balance = 10000.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Account
            {
                Code = "1200",
                Name = "Accounts Receivable",
                AccountType = AccountType.Asset,
                Balance = 5000.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Account
            {
                Code = "1300",
                Name = "Inventory",
                AccountType = AccountType.Asset,
                Balance = 15000.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Account
            {
                Code = "1500",
                Name = "Equipment",
                AccountType = AccountType.Asset,
                Balance = 25000.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },

            // Liabilities
            new Account
            {
                Code = "2100",
                Name = "Accounts Payable",
                AccountType = AccountType.Liability,
                Balance = 3000.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Account
            {
                Code = "2200",
                Name = "Notes Payable",
                AccountType = AccountType.Liability,
                Balance = 8000.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },

            // Equity
            new Account
            {
                Code = "3100",
                Name = "Owner's Equity",
                AccountType = AccountType.Equity,
                Balance = 40000.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Account
            {
                Code = "3200",
                Name = "Retained Earnings",
                AccountType = AccountType.Equity,
                Balance = 4000.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },

            // Revenue
            new Account
            {
                Code = "4100",
                Name = "Sales Revenue",
                AccountType = AccountType.Revenue,
                Balance = 0.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Account
            {
                Code = "4200",
                Name = "Service Revenue",
                AccountType = AccountType.Revenue,
                Balance = 0.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },

            // Expenses
            new Account
            {
                Code = "5100",
                Name = "Cost of Goods Sold",
                AccountType = AccountType.Expense,
                Balance = 0.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Account
            {
                Code = "5200",
                Name = "Rent Expense",
                AccountType = AccountType.Expense,
                Balance = 0.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Account
            {
                Code = "5300",
                Name = "Utilities Expense",
                AccountType = AccountType.Expense,
                Balance = 0.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Account
            {
                Code = "5400",
                Name = "Marketing Expense",
                AccountType = AccountType.Expense,
                Balance = 0.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new Account
            {
                Code = "5500",
                Name = "Office Supplies Expense",
                AccountType = AccountType.Expense,
                Balance = 0.00m,
                CompanyId = company.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        context.Accounts.AddRange(accounts);
        await context.SaveChangesAsync();
    }

    private static async Task SeedFiscalYearsAsync(AccountingDbContext context)
    {
        var company = await context.Companies.FirstAsync();
        
        var currentYear = DateTime.UtcNow.Year;
        var fiscalYears = new List<FiscalYear>
        {
            new FiscalYear
            {
                Year = currentYear,
                StartDate = new DateTime(currentYear, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(currentYear, 12, 31, 23, 59, 59, DateTimeKind.Utc),
                Status = FiscalYearStatus.Open,
                IsCurrent = true,
                CompanyId = company.Id,
                CreatedAt = DateTime.UtcNow
            },
            new FiscalYear
            {
                Year = currentYear + 1,
                StartDate = new DateTime(currentYear + 1, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(currentYear + 1, 12, 31, 23, 59, 59, DateTimeKind.Utc),
                Status = FiscalYearStatus.Open,
                IsCurrent = false,
                CompanyId = company.Id,
                CreatedAt = DateTime.UtcNow
            }
        };

        context.FiscalYears.AddRange(fiscalYears);
        await context.SaveChangesAsync();
    }

    private static async Task SeedAccountingPeriodsAsync(AccountingDbContext context)
    {
        var fiscalYear = await context.FiscalYears
            .Where(fy => fy.Status == FiscalYearStatus.Open)
            .FirstAsync();

        var periods = new List<AccountingPeriod>();
        
        for (int month = 1; month <= 12; month++)
        {
            var startDate = new DateTime(fiscalYear.StartDate.Year, month, 1, 0, 0, 0, DateTimeKind.Utc);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            
            periods.Add(new AccountingPeriod
            {
                Name = $"{startDate:MMMM yyyy}",
                StartDate = startDate,
                EndDate = endDate,
                Status = month <= DateTime.UtcNow.Month ? AccountingPeriodStatus.Open : AccountingPeriodStatus.Closed,
                FiscalYearId = fiscalYear.Id,
                CreatedAt = DateTime.UtcNow
            });
        }

        context.AccountingPeriods.AddRange(periods);
        await context.SaveChangesAsync();
    }
}