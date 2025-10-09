using AccountingPro.Application.DTOs;
using AccountingPro.Application.Services;
using AccountingPro.Core.Entities;
using AccountingPro.Core.Enums;
using AccountingPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Services;

public class BalanceSheetService : IBalanceSheetService
{
    private readonly AccountingDbContext _context;

    public BalanceSheetService(AccountingDbContext context)
    {
        _context = context;
    }

    public Task<List<BalanceSheetAccountTemplateDto>> GetBalanceSheetTemplatesAsync()
    {
        return Task.FromResult(new List<BalanceSheetAccountTemplateDto>
        {
            // Fixed Assets
            new() { Category = "Fixed Assets", AccountCode = "1100", AccountName = "Equipment", AccountType = AccountType.Asset, Description = "Equipment and machinery" },
            new() { Category = "Fixed Assets", AccountCode = "1110", AccountName = "Furniture & Fixtures", AccountType = AccountType.Asset, Description = "Office furniture and fixtures" },
            new() { Category = "Fixed Assets", AccountCode = "1120", AccountName = "Vehicles", AccountType = AccountType.Asset, Description = "Company vehicles" },
            
            // Current Assets
            new() { Category = "Current Assets", AccountCode = "1200", AccountName = "Cash in Hand", AccountType = AccountType.Asset, Description = "Physical cash on hand" },
            new() { Category = "Current Assets", AccountCode = "1210", AccountName = "Cash at Bank", AccountType = AccountType.Asset, Description = "Bank account balances" },
            new() { Category = "Current Assets", AccountCode = "1220", AccountName = "Deposit - Rental", AccountType = AccountType.Asset, Description = "Rental deposits paid" },
            new() { Category = "Current Assets", AccountCode = "1221", AccountName = "Deposit - Electricity", AccountType = AccountType.Asset, Description = "Electricity deposits paid" },
            new() { Category = "Current Assets", AccountCode = "1222", AccountName = "Deposit - Water", AccountType = AccountType.Asset, Description = "Water deposits paid" },
            new() { Category = "Current Assets", AccountCode = "1230", AccountName = "Stock", AccountType = AccountType.Asset, Description = "Inventory/Stock on hand" },
            new() { Category = "Current Assets", AccountCode = "1240", AccountName = "Accounts Receivable", AccountType = AccountType.Asset, Description = "Money owed by customers" },
            
            // Current Liabilities
            new() { Category = "Current Liabilities", AccountCode = "2100", AccountName = "Creditor", AccountType = AccountType.Liability, Description = "Accounts payable/creditors" },
            new() { Category = "Current Liabilities", AccountCode = "2110", AccountName = "Accruals", AccountType = AccountType.Liability, Description = "Accrued expenses" },
            new() { Category = "Current Liabilities", AccountCode = "2120", AccountName = "Short-term Loan", AccountType = AccountType.Liability, Description = "Short-term loans payable" },
            
            // Capital Account
            new() { Category = "Capital Account", AccountCode = "3000", AccountName = "Owner's Capital", AccountType = AccountType.Equity, Description = "Owner's capital contribution" },
            new() { Category = "Capital Account", AccountCode = "3100", AccountName = "Retained Earnings", AccountType = AccountType.Equity, Description = "Accumulated profits/losses" },
            new() { Category = "Capital Account", AccountCode = "3200", AccountName = "Drawings", AccountType = AccountType.Equity, Description = "Owner's drawings/withdrawals" },
        });
    }

    public async Task CreateOpeningBalancesAsync(OpeningBalanceSheetDto dto, int companyId)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        
        await strategy.ExecuteAsync(async () =>
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            
            try
            {
                var journalEntry = new JournalEntry
                {
                    EntryNumber = await GenerateEntryNumberAsync(companyId),
                    EntryDate = dto.AsOfDate,
                    Description = $"Opening Balance Sheet as of {dto.AsOfDate:yyyy-MM-dd}",
                    Reference = "OPENING-BAL",
                    Status = JournalEntryStatus.Approved,
                    CompanyId = companyId,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                };

                _context.JournalEntries.Add(journalEntry);
                await _context.SaveChangesAsync();

                var journalLines = new List<JournalEntryLine>();

                // Fixed Assets (Debit)
                foreach (var asset in dto.FixedAssets.Where(a => a.Amount > 0))
                {
                    var account = await EnsureAccountExists(asset, companyId);
                    journalLines.Add(new JournalEntryLine
                    {
                        JournalEntryId = journalEntry.Id,
                        AccountId = account.Id,
                        DebitAmount = asset.Amount,
                        CreditAmount = 0,
                        Description = $"Opening balance - {asset.AccountName}",
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = "System"
                    });
                    
                    // Update account balance
                    account.Balance += asset.Amount;
                }

                // Current Assets (Debit)
                foreach (var asset in dto.CurrentAssets.Where(a => a.Amount > 0))
                {
                    var account = await EnsureAccountExists(asset, companyId);
                    journalLines.Add(new JournalEntryLine
                    {
                        JournalEntryId = journalEntry.Id,
                        AccountId = account.Id,
                        DebitAmount = asset.Amount,
                        CreditAmount = 0,
                        Description = $"Opening balance - {asset.AccountName}",
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = "System"
                    });
                    
                    account.Balance += asset.Amount;
                }

                // Current Liabilities (Credit)
                foreach (var liability in dto.CurrentLiabilities.Where(l => l.Amount > 0))
                {
                    var account = await EnsureAccountExists(liability, companyId);
                    journalLines.Add(new JournalEntryLine
                    {
                        JournalEntryId = journalEntry.Id,
                        AccountId = account.Id,
                        DebitAmount = 0,
                        CreditAmount = liability.Amount,
                        Description = $"Opening balance - {liability.AccountName}",
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = "System"
                    });
                    
                    account.Balance += liability.Amount;
                }

                // Capital Account (Credit)
                foreach (var capital in dto.CapitalAccount.Where(c => c.Amount > 0))
                {
                    var account = await EnsureAccountExists(capital, companyId);
                    journalLines.Add(new JournalEntryLine
                    {
                        JournalEntryId = journalEntry.Id,
                        AccountId = account.Id,
                        DebitAmount = 0,
                        CreditAmount = capital.Amount,
                        Description = $"Opening balance - {capital.AccountName}",
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = "System"
                    });
                    
                    account.Balance += capital.Amount;
                }

                // Drawings (Debit - reduces equity)
                if (dto.Drawings > 0)
                {
                    var drawingsAccount = await GetOrCreateDrawingsAccount(companyId);
                    journalLines.Add(new JournalEntryLine
                    {
                        JournalEntryId = journalEntry.Id,
                        AccountId = drawingsAccount.Id,
                        DebitAmount = dto.Drawings,
                        CreditAmount = 0,
                        Description = "Opening balance - Drawings",
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = "System"
                    });
                    
                    drawingsAccount.Balance += dto.Drawings;
                }

                _context.JournalEntryLines.AddRange(journalLines);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        });
    }

    public async Task<OpeningBalanceSheetDto?> GetOpeningBalancesAsync(int companyId)
    {
        var openingEntry = await _context.JournalEntries
            .AsNoTracking()
            .Include(j => j.JournalEntryLines)
            .ThenInclude(l => l.Account)
            .Where(j => j.CompanyId == companyId && j.Reference == "OPENING-BAL")
            .OrderBy(j => j.EntryDate)
            .FirstOrDefaultAsync();

        if (openingEntry == null)
            return null;

        var dto = new OpeningBalanceSheetDto
        {
            AsOfDate = openingEntry.EntryDate,
            Notes = openingEntry.Description ?? ""
        };

        foreach (var line in openingEntry.JournalEntryLines)
        {
            var entry = new BalanceSheetEntryDto
            {
                AccountId = line.AccountId,
                AccountCode = line.Account.Code,
                AccountName = line.Account.Name,
                AccountType = line.Account.AccountType,
                Amount = line.DebitAmount > 0 ? line.DebitAmount : line.CreditAmount
            };

            // Categorize based on account type and code
            if (line.Account.Code.StartsWith("11") && line.Account.AccountType == AccountType.Asset)
            {
                dto.FixedAssets.Add(entry);
            }
            else if (line.Account.Code.StartsWith("12") && line.Account.AccountType == AccountType.Asset)
            {
                dto.CurrentAssets.Add(entry);
            }
            else if (line.Account.AccountType == AccountType.Liability)
            {
                dto.CurrentLiabilities.Add(entry);
            }
            else if (line.Account.AccountType == AccountType.Equity)
            {
                if (line.Account.Name.Contains("Drawing", StringComparison.OrdinalIgnoreCase))
                {
                    dto.Drawings = entry.Amount;
                }
                else
                {
                    dto.CapitalAccount.Add(entry);
                }
            }
        }

        return dto;
    }

    private async Task<Account> EnsureAccountExists(BalanceSheetEntryDto dto, int companyId)
    {
        var account = await _context.Accounts
            .FirstOrDefaultAsync(a => a.Code == dto.AccountCode && a.CompanyId == companyId);

        if (account == null)
        {
            account = new Account
            {
                Code = dto.AccountCode,
                Name = dto.AccountName,
                AccountType = dto.AccountType,
                CompanyId = companyId,
                IsActive = true,
                Balance = 0,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System"
            };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        return account;
    }

    private async Task<Account> GetOrCreateDrawingsAccount(int companyId)
    {
        var account = await _context.Accounts
            .FirstOrDefaultAsync(a => a.Code == "3200" && a.CompanyId == companyId);

        if (account == null)
        {
            account = new Account
            {
                Code = "3200",
                Name = "Drawings",
                Description = "Owner's drawings/withdrawals",
                AccountType = AccountType.Equity,
                CompanyId = companyId,
                IsActive = true,
                Balance = 0,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System"
            };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        return account;
    }

    private async Task<string> GenerateEntryNumberAsync(int companyId)
    {
        var lastEntry = await _context.JournalEntries
            .Where(j => j.CompanyId == companyId)
            .OrderByDescending(j => j.Id)
            .FirstOrDefaultAsync();

        if (lastEntry == null || string.IsNullOrEmpty(lastEntry.EntryNumber))
        {
            return "JE-000001";
        }

        var lastNumber = int.Parse(lastEntry.EntryNumber.Split('-')[1]);
        return $"JE-{(lastNumber + 1):D6}";
    }
}
