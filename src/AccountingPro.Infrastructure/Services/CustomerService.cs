using AccountingPro.Application.DTOs;
using AccountingPro.Application.Services;
using AccountingPro.Core.Entities;
using AccountingPro.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly IDbContextFactory<AccountingDbContext> _contextFactory;
    private readonly IMapper _mapper;
    private readonly ICompanyContextService _companyContext;
    private const string NoCompanyContextError = "No company context set";

    public CustomerService(IDbContextFactory<AccountingDbContext> contextFactory, IMapper mapper, ICompanyContextService companyContext)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _companyContext = companyContext;
    }

    public async Task<List<CustomerDto>> GetAllCustomersAsync()
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        await using var context = await _contextFactory.CreateDbContextAsync();
        var customers = await context.Customers
            .Where(c => c.CompanyId == _companyContext.CurrentCompanyId)
            .OrderBy(c => c.Name)
            .ToListAsync();

        return _mapper.Map<List<CustomerDto>>(customers);
    }

    public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers
            .FirstOrDefaultAsync(c => c.Id == id && c.CompanyId == _companyContext.CurrentCompanyId);

        return customer == null ? null : _mapper.Map<CustomerDto>(customer);
    }

    public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        var customer = _mapper.Map<Customer>(createCustomerDto);
        customer.CompanyId = _companyContext.CurrentCompanyId.Value;
        customer.CreatedAt = DateTime.UtcNow;
        customer.CreatedBy = "System"; // Should be current user in real implementation

        await using var context = await _contextFactory.CreateDbContextAsync();
        context.Customers.Add(customer);
        await context.SaveChangesAsync();

        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<CustomerDto?> UpdateCustomerAsync(int id, UpdateCustomerDto updateCustomerDto)
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers
            .FirstOrDefaultAsync(c => c.Id == id && c.CompanyId == _companyContext.CurrentCompanyId);

        if (customer == null)
            return null;

        _mapper.Map(updateCustomerDto, customer);
        customer.UpdatedAt = DateTime.UtcNow;
        customer.UpdatedBy = "System"; // Should be current user in real implementation

        await context.SaveChangesAsync();

        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers
            .FirstOrDefaultAsync(c => c.Id == id && c.CompanyId == _companyContext.CurrentCompanyId);

        if (customer == null)
            return false;

        context.Customers.Remove(customer);
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<List<CustomerDto>> GetCustomersByCompanyIdAsync(int companyId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var customers = await context.Customers
            .Where(c => c.CompanyId == companyId)
            .OrderBy(c => c.Name)
            .ToListAsync();

        return _mapper.Map<List<CustomerDto>>(customers);
    }
}
