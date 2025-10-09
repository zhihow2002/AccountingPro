using AccountingPro.Application.DTOs;
using AccountingPro.Application.Services;
using AccountingPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Services;

public class CountryService : ICountryService
{
    private readonly AccountingDbContext _context;

    public CountryService(AccountingDbContext context)
    {
        _context = context;
    }

    public async Task<List<CountryDto>> GetAllCountriesAsync()
    {
        return await _context.Countries
            .Where(c => c.IsActive)
            .OrderBy(c => c.Name)
            .Select(c => new CountryDto
            {
                Id = c.Id,
                Code = c.Code,
                Name = c.Name,
                Code3 = c.Code3,
                PhoneCode = c.PhoneCode,
                Currency = c.Currency,
                CurrencySymbol = c.CurrencySymbol
            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<CountryDto?> GetCountryByCodeAsync(string code)
    {
        var country = await _context.Countries
            .Where(c => c.Code == code && c.IsActive)
            .Select(c => new CountryDto
            {
                Id = c.Id,
                Code = c.Code,
                Name = c.Name,
                Code3 = c.Code3,
                PhoneCode = c.PhoneCode,
                Currency = c.Currency,
                CurrencySymbol = c.CurrencySymbol
            })
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return country;
    }
}
