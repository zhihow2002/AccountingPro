using AccountingPro.Application.DTOs;

namespace AccountingPro.Application.Services;

public interface IBillService
{
    Task<List<BillDto>> GetAllBillsAsync();
    Task<BillDto?> GetBillByIdAsync(int id);
    Task<BillDto> CreateBillAsync(CreateBillDto createBillDto);
    Task<BillDto?> UpdateBillAsync(int id, BillDto updateBillDto);
    Task<bool> DeleteBillAsync(int id);
    Task<List<BillDto>> GetBillsBySupplierIdAsync(int supplierId);
}
