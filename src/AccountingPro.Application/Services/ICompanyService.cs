using AccountingPro.Core.Entities;

namespace AccountingPro.Application.Services;

public interface ICompanyService
{
    Task<List<Company>> GetAllCompaniesAsync();
    Task<Company?> GetCompanyByIdAsync(int id);
    Task<Company> CreateCompanyAsync(Company company);
    Task<Company> UpdateCompanyAsync(Company company);
    Task DeleteCompanyAsync(int id);
    Task<bool> CompanyExistsAsync(int id);
    Task<bool> CompanyCodeExistsAsync(string code, int? excludeId = null);
}