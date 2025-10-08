using AccountingPro.Core.Entities;

namespace AccountingPro.Application.Services;

public interface ICompanyContextService
{
    int? CurrentCompanyId { get; }
    Company? CurrentCompany { get; }
    Task SetCurrentCompanyAsync(int companyId);
    Task ClearCurrentCompanyAsync();
    Task<List<Company>> GetUserCompaniesAsync();
}

public class CompanyContextService : ICompanyContextService
{
    private int? _currentCompanyId;
    private Company? _currentCompany;
    private readonly ICompanyService _companyService;

    public CompanyContextService(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public int? CurrentCompanyId => _currentCompanyId;
    public Company? CurrentCompany => _currentCompany;

    public async Task SetCurrentCompanyAsync(int companyId)
    {
        _currentCompanyId = companyId;
        _currentCompany = await _companyService.GetCompanyByIdAsync(companyId);
    }

    public async Task ClearCurrentCompanyAsync()
    {
        _currentCompanyId = null;
        _currentCompany = null;
    }

    public async Task<List<Company>> GetUserCompaniesAsync()
    {
        // In a real application, this would filter by user permissions
        // For now, return all companies
        return await _companyService.GetAllCompaniesAsync();
    }
}