using AccountingPro.Application.DTOs;

namespace AccountingPro.Application.Services;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto?> GetCustomerByIdAsync(int id);
    Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto);
    Task<CustomerDto?> UpdateCustomerAsync(int id, UpdateCustomerDto updateCustomerDto);
    Task<bool> DeleteCustomerAsync(int id);
    Task<List<CustomerDto>> GetCustomersByCompanyIdAsync(int companyId);
}
