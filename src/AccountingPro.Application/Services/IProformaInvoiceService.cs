using AccountingPro.Application.DTOs;

namespace AccountingPro.Application.Services
{
    public interface IProformaInvoiceService
    {
        Task<List<ProformaInvoiceListDto>> GetAllProformaInvoicesAsync(int companyId);
        Task<ProformaInvoiceDto?> GetProformaInvoiceByIdAsync(int id);
        Task<ProformaInvoiceDto> CreateProformaInvoiceAsync(CreateProformaInvoiceDto createDto, int companyId);
        Task<ProformaInvoiceDto?> UpdateProformaInvoiceAsync(int id, UpdateProformaInvoiceDto updateDto);
        Task<bool> DeleteProformaInvoiceAsync(int id);
        Task<ProformaInvoiceDto?> ConvertToInvoiceAsync(int proformaId);
        Task<List<ProformaInvoiceListDto>> GetProformaInvoicesByCustomerIdAsync(int customerId, int companyId);
        Task<bool> UpdateStatusAsync(int id, Core.Enums.ProformaStatus status);
    }
}
