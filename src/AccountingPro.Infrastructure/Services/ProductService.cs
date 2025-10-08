using AccountingPro.Application.DTOs;
using AccountingPro.Application.Services;
using AccountingPro.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly AccountingDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICompanyContextService _companyContext;
    private const string NoCompanyContextError = "No company context set";

    public ProductService(AccountingDbContext context, IMapper mapper, ICompanyContextService companyContext)
    {
        _context = context;
        _mapper = mapper;
        _companyContext = companyContext;
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        var products = await _context.Products
            .Where(p => p.IsActive && p.CompanyId == _companyContext.CurrentCompanyId)
            .OrderBy(p => p.Name)
            .ToListAsync();

        return _mapper.Map<List<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id && p.CompanyId == _companyContext.CurrentCompanyId);

        return product == null ? null : _mapper.Map<ProductDto>(product);
    }

    public async Task<List<ProductDto>> GetProductsByCompanyIdAsync(int companyId)
    {
        var products = await _context.Products
            .Where(p => p.IsActive && p.CompanyId == companyId)
            .OrderBy(p => p.Name)
            .ToListAsync();

        return _mapper.Map<List<ProductDto>>(products);
    }
}