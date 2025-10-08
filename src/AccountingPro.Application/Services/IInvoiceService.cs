using AccountingPro.Application.DTOs;

namespace AccountingPro.Application.Services;

public interface IInvoiceService
{
    Task<List<InvoiceDto>> GetAllInvoicesAsync();
    Task<InvoiceDto?> GetInvoiceByIdAsync(int id);
    Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceDto createInvoiceDto);
    Task<InvoiceDto?> UpdateInvoiceAsync(int id, InvoiceDto updateInvoiceDto);
    Task<bool> DeleteInvoiceAsync(int id);
    Task<List<InvoiceDto>> GetInvoicesByCustomerIdAsync(int customerId);
    Task<List<InvoiceDto>> GetInvoicesByCompanyIdAsync(int companyId);
}
