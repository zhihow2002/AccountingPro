using AccountingPro.Application.Services;
using AccountingPro.Core.Entities;
using AccountingPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Services;

public class CompanyService : ICompanyService
{
    private readonly IDbContextFactory<AccountingDbContext> _contextFactory;

    public CompanyService(IDbContextFactory<AccountingDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Company>> GetAllCompaniesAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Companies.AsNoTracking().OrderBy(c => c.Name).ToListAsync();
    }

    public async Task<Company?> GetCompanyByIdAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Company> CreateCompanyAsync(Company company)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        // Check if company code already exists
        if (await CompanyCodeExistsAsync(company.Code))
        {
            throw new InvalidOperationException($"Company code '{company.Code}' already exists.");
        }

        context.Companies.Add(company);
        await context.SaveChangesAsync();
        return company;
    }

    public async Task<Company> UpdateCompanyAsync(Company company)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        // Check if company code already exists for a different company
        if (await CompanyCodeExistsAsync(company.Code, company.Id))
        {
            throw new InvalidOperationException($"Company code '{company.Code}' already exists.");
        }

        context.Companies.Update(company);
        await context.SaveChangesAsync();
        return company;
    }

    public async Task DeleteCompanyAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var company = await context.Companies.FindAsync(id);
        if (company != null)
        {
            context.Companies.Remove(company);
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> CompanyExistsAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Companies.AnyAsync(c => c.Id == id);
    }

    public async Task<bool> CompanyCodeExistsAsync(string code, int? excludeId = null)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var query = context.Companies.Where(c => c.Code == code);
        if (excludeId.HasValue)
        {
            query = query.Where(c => c.Id != excludeId.Value);
        }
        return await query.AnyAsync();
    }
}
