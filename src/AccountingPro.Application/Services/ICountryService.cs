using AccountingPro.Application.DTOs;

namespace AccountingPro.Application.Services;

public interface ICountryService
{
    Task<List<CountryDto>> GetAllCountriesAsync();
    Task<CountryDto?> GetCountryByCodeAsync(string code);
}
