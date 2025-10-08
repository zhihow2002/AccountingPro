using AccountingPro.Application.DTOs;

namespace AccountingPro.Application.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<List<ProductDto>> GetProductsByCompanyIdAsync(int companyId);
}
