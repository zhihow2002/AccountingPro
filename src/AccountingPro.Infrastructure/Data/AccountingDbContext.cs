using AccountingPro.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Data;

public class AccountingDbContext : DbContext
{
    private const string SYSTEM_USER = "System";

    public AccountingDbContext(DbContextOptions<AccountingDbContext> options)
        : base(options) { }

    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<JournalEntry> JournalEntries { get; set; } = null!;
    public DbSet<JournalEntryLine> JournalEntryLines { get; set; } = null!;
    public DbSet<FiscalYear> FiscalYears { get; set; } = null!;
    public DbSet<AccountingPeriod> AccountingPeriods { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Company configuration
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.TaxId).HasMaxLength(50);
            entity.HasIndex(e => e.Code).IsUnique();
        });

        // Account configuration
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Balance).HasPrecision(18, 2);

            entity
                .HasOne(e => e.Company)
                .WithMany(c => c.Accounts)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(e => e.ParentAccount)
                .WithMany(a => a.ChildAccounts)
                .HasForeignKey(e => e.ParentAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => new { e.CompanyId, e.Code }).IsUnique();
        });

        // JournalEntry configuration
        modelBuilder.Entity<JournalEntry>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.EntryNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Reference).HasMaxLength(200);
            entity.Property(e => e.TotalDebit).HasPrecision(18, 2);
            entity.Property(e => e.TotalCredit).HasPrecision(18, 2);

            entity
                .HasOne(e => e.Company)
                .WithMany(c => c.JournalEntries)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(e => e.ReversalOfEntry)
                .WithMany()
                .HasForeignKey(e => e.ReversalOfEntryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => new { e.CompanyId, e.EntryNumber }).IsUnique();
        });

        // JournalEntryLine configuration
        modelBuilder.Entity<JournalEntryLine>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.DebitAmount).HasPrecision(18, 2);
            entity.Property(e => e.CreditAmount).HasPrecision(18, 2);

            entity
                .HasOne(e => e.JournalEntry)
                .WithMany(je => je.JournalEntryLines)
                .HasForeignKey(e => e.JournalEntryId)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasOne(e => e.Account)
                .WithMany(a => a.JournalEntryLines)
                .HasForeignKey(e => e.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // FiscalYear configuration
        modelBuilder.Entity<FiscalYear>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Year).IsRequired();

            entity
                .HasOne(e => e.Company)
                .WithMany(c => c.FiscalYears)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => new { e.CompanyId, e.Year }).IsUnique();
        });

        // AccountingPeriod configuration
        modelBuilder.Entity<AccountingPeriod>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

            entity
                .HasOne(e => e.FiscalYear)
                .WithMany(fy => fy.AccountingPeriods)
                .HasForeignKey(e => e.FiscalYearId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Customer configuration
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.CompanyName).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreditLimit).HasPrecision(18, 2);
            entity.Property(e => e.OutstandingBalance).HasPrecision(18, 2);
        });

        // Seed data for account types
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed default company
        modelBuilder
            .Entity<Company>()
            .HasData(
                new Company
                {
                    Id = 1,
                    Name = "Sample Company Ltd.",
                    Code = "SAMPLE",
                    Address = "123 Business Street, City, State 12345",
                    Phone = "+1-555-0123",
                    Email = "info@samplecompany.com",
                    TaxId = "12-3456789",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = SYSTEM_USER
                }
            );

        // Seed chart of accounts
        var accounts = new[]
        {
            // Assets
            new Account
            {
                Id = 1,
                Code = "1000",
                Name = "Cash",
                Description = "Cash and cash equivalents",
                AccountType = Core.Enums.AccountType.Asset,
                CompanyId = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = SYSTEM_USER
            },
            new Account
            {
                Id = 2,
                Code = "1100",
                Name = "Accounts Receivable",
                Description = "Money owed by customers",
                AccountType = Core.Enums.AccountType.Asset,
                CompanyId = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = SYSTEM_USER
            },
            new Account
            {
                Id = 3,
                Code = "1200",
                Name = "Inventory",
                Description = "Goods for sale",
                AccountType = Core.Enums.AccountType.Asset,
                CompanyId = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = SYSTEM_USER
            },
            // Liabilities
            new Account
            {
                Id = 4,
                Code = "2000",
                Name = "Accounts Payable",
                Description = "Money owed to suppliers",
                AccountType = Core.Enums.AccountType.Liability,
                CompanyId = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = SYSTEM_USER
            },
            new Account
            {
                Id = 5,
                Code = "2100",
                Name = "Bank Loan",
                Description = "Long-term debt",
                AccountType = Core.Enums.AccountType.Liability,
                CompanyId = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = SYSTEM_USER
            },
            // Equity
            new Account
            {
                Id = 6,
                Code = "3000",
                Name = "Owner's Equity",
                Description = "Owner's investment in business",
                AccountType = Core.Enums.AccountType.Equity,
                CompanyId = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = SYSTEM_USER
            },
            // Revenue
            new Account
            {
                Id = 7,
                Code = "4000",
                Name = "Sales Revenue",
                Description = "Income from sales",
                AccountType = Core.Enums.AccountType.Revenue,
                CompanyId = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = SYSTEM_USER
            },
            // Expenses
            new Account
            {
                Id = 8,
                Code = "5000",
                Name = "Cost of Goods Sold",
                Description = "Direct costs of production",
                AccountType = Core.Enums.AccountType.Expense,
                CompanyId = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = SYSTEM_USER
            },
            new Account
            {
                Id = 9,
                Code = "5100",
                Name = "Rent Expense",
                Description = "Office rent",
                AccountType = Core.Enums.AccountType.Expense,
                CompanyId = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = SYSTEM_USER
            },
            new Account
            {
                Id = 10,
                Code = "5200",
                Name = "Utilities Expense",
                Description = "Electricity, water, etc.",
                AccountType = Core.Enums.AccountType.Expense,
                CompanyId = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = SYSTEM_USER
            }
        };

        modelBuilder.Entity<Account>().HasData(accounts);

        // Seed fiscal year
        modelBuilder
            .Entity<FiscalYear>()
            .HasData(
                new FiscalYear
                {
                    Id = 1,
                    Year = 2024,
                    StartDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Unspecified),
                    EndDate = new DateTime(2024, 12, 31, 23, 59, 59, DateTimeKind.Unspecified),
                    Status = Core.Enums.FiscalYearStatus.Open,
                    CompanyId = 1,
                    IsCurrent = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = SYSTEM_USER
                }
            );
    }
}
