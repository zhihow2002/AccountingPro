using AccountingPro.Application.Services;
using AccountingPro.Core.Entities;
using AccountingPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Services;

public class CompanyService : ICompanyService
{
    private readonly AccountingDbContext _context;

    public CompanyService(AccountingDbContext context)
    {
        _context = context;
    }

    public async Task<List<Company>> GetAllCompaniesAsync()
    {
        return await _context.Companies
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Company?> GetCompanyByIdAsync(int id)
    {
        return await _context.Companies
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Company> CreateCompanyAsync(Company company)
    {
        // Check if company code already exists
        if (await CompanyCodeExistsAsync(company.Code))
        {
            throw new InvalidOperationException($"Company code '{company.Code}' already exists.");
        }

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task<Company> UpdateCompanyAsync(Company company)
    {
        // Check if company code already exists for a different company
        if (await CompanyCodeExistsAsync(company.Code, company.Id))
        {
            throw new InvalidOperationException($"Company code '{company.Code}' already exists.");
        }

        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task DeleteCompanyAsync(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company != null)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> CompanyExistsAsync(int id)
    {
        return await _context.Companies.AnyAsync(c => c.Id == id);
    }

    public async Task<bool> CompanyCodeExistsAsync(string code, int? excludeId = null)
    {
        var query = _context.Companies.Where(c => c.Code == code);
        if (excludeId.HasValue)
        {
            query = query.Where(c => c.Id != excludeId.Value);
        }
        return await query.AnyAsync();
    }
}