using AccountingPro.Core.Entities;

namespace AccountingPro.Application.Services;

public interface ICompanyContextService
{
    int? CurrentCompanyId { get; }
    Company? CurrentCompany { get; }
    Task InitializeAsync();
    Task SetCurrentCompanyAsync(int companyId);
    Task ClearCurrentCompanyAsync();
    Task<List<Company>> GetUserCompaniesAsync();
}

public class CompanyContextService : ICompanyContextService
{
    private int? _currentCompanyId;
    private Company? _currentCompany;
    private readonly ICompanyService _companyService;
    private readonly SemaphoreSlim _initializationLock = new(1, 1);
    private bool _isInitialized;

    public CompanyContextService(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public int? CurrentCompanyId => _currentCompanyId;
    public Company? CurrentCompany => _currentCompany;

    public async Task InitializeAsync()
    {
        if (_isInitialized)
        {
            return;
        }

        await _initializationLock.WaitAsync();
        try
        {
            if (_isInitialized)
            {
                return;
            }

            await InitializeDefaultCompanyAsync();
            _isInitialized = true;
        }
        finally
        {
            _initializationLock.Release();
        }
    }

    public async Task SetCurrentCompanyAsync(int companyId)
    {
        _currentCompanyId = companyId;
        _currentCompany = await _companyService.GetCompanyByIdAsync(companyId);
    }

    public Task ClearCurrentCompanyAsync()
    {
        _currentCompanyId = null;
        _currentCompany = null;
        _isInitialized = false;
        return Task.CompletedTask;
    }

    public async Task<List<Company>> GetUserCompaniesAsync()
    {
        // In a real application, this would filter by user permissions
        // For now, return all companies
        return await _companyService.GetAllCompaniesAsync();
    }

    private async Task InitializeDefaultCompanyAsync()
    {
        try
        {
            var companies = await _companyService.GetAllCompaniesAsync();

            var defaultCompany = companies.FirstOrDefault(c => c.IsActive);
            if (defaultCompany == null)
            {
                defaultCompany = companies.FirstOrDefault();
            }

            if (defaultCompany != null)
            {
                _currentCompanyId = defaultCompany.Id;
                _currentCompany = defaultCompany;
            }
        }
        catch
        {
            // If we cannot load companies (e.g., during migrations), leave context unset
        }
    }
}
