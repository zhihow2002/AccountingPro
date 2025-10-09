using AccountingPro.Application.DTOs;
using AccountingPro.Application.Services;
using AccountingPro.Core.Entities;
using AccountingPro.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Services;

public class BillService : IBillService
{
    private readonly AccountingDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICompanyContextService _companyContext;
    private const string NoCompanyContextError =
        "No company context is set. Please select a company.";

    public BillService(
        AccountingDbContext context,
        IMapper mapper,
        ICompanyContextService companyContext
    )
    {
        _context = context;
        _mapper = mapper;
        _companyContext = companyContext;
    }

    public async Task<List<BillDto>> GetAllBillsAsync()
    {
        if (_companyContext.CurrentCompanyId == null)
            return new List<BillDto>();

        var bills = await _context
            .Bills.Include(b => b.Supplier)
            .Include(b => b.BillItems)
            .Where(b => b.CompanyId == _companyContext.CurrentCompanyId)
            .OrderByDescending(b => b.BillDate)
            .ToListAsync();

        return _mapper.Map<List<BillDto>>(bills);
    }

    public async Task<BillDto?> GetBillByIdAsync(int id)
    {
        var bill = await _context
            .Bills.Include(b => b.Supplier)
            .Include(b => b.BillItems)
            .ThenInclude(bi => bi.Product)
            .FirstOrDefaultAsync(b => b.Id == id);

        return bill == null ? null : _mapper.Map<BillDto>(bill);
    }

    public async Task<BillDto> CreateBillAsync(CreateBillDto createBillDto)
    {
        // Generate bill number
        var lastBill = await _context.Bills.OrderByDescending(b => b.Id).FirstOrDefaultAsync();

        var billNumber = $"BILL-{DateTime.Now:yyyyMM}-{(lastBill?.Id ?? 0) + 1:D4}";

        var bill = new Bill
        {
            BillNumber = billNumber,
            SupplierId = createBillDto.SupplierId,
            BillDate = createBillDto.BillDate,
            DueDate = createBillDto.DueDate,
            DiscountAmount = createBillDto.DiscountAmount,
            Notes = createBillDto.Notes,
            Status = Core.Enums.BillStatus.Draft,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System" // Should be current user in real implementation
        };

        // Add bill items
        foreach (var itemDto in createBillDto.LineItems)
        {
            var billItem = new BillItem
            {
                ProductId = itemDto.ProductId == 0 ? null : itemDto.ProductId,
                Description = itemDto.Description,
                Quantity = itemDto.Quantity,
                UnitPrice = itemDto.UnitPrice,
                TaxRate = itemDto.TaxRate,
                TaxAmount = (itemDto.Quantity * itemDto.UnitPrice) * (itemDto.TaxRate / 100),
                LineTotal =
                    (itemDto.Quantity * itemDto.UnitPrice)
                    + ((itemDto.Quantity * itemDto.UnitPrice) * (itemDto.TaxRate / 100)),
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System"
            };
            bill.BillItems.Add(billItem);
        }

        // Calculate totals
        bill.SubTotal = bill.BillItems.Sum(b => b.Quantity * b.UnitPrice);
        bill.TaxAmount = bill.BillItems.Sum(b => b.TaxAmount);
        bill.TotalAmount = bill.SubTotal + bill.TaxAmount - bill.DiscountAmount;
        bill.BalanceAmount = bill.TotalAmount - bill.PaidAmount;

        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();

        return _mapper.Map<BillDto>(bill);
    }

    public async Task<BillDto?> UpdateBillAsync(int id, BillDto updateBillDto)
    {
        var bill = await _context
            .Bills.Include(b => b.BillItems)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (bill == null)
            return null;

        // Update bill properties
        bill.BillDate = updateBillDto.BillDate;
        bill.DueDate = updateBillDto.DueDate;
        bill.DiscountAmount = updateBillDto.DiscountAmount;
        bill.Notes = updateBillDto.Notes;
        bill.Status = updateBillDto.Status;
        bill.UpdatedAt = DateTime.UtcNow;
        bill.UpdatedBy = "System"; // Should be current user in real implementation

        await _context.SaveChangesAsync();

        return _mapper.Map<BillDto>(bill);
    }

    public async Task<bool> DeleteBillAsync(int id)
    {
        var bill = await _context.Bills.FirstOrDefaultAsync(b => b.Id == id);

        if (bill == null)
            return false;

        _context.Bills.Remove(bill);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<BillDto>> GetBillsBySupplierIdAsync(int supplierId)
    {
        var bills = await _context
            .Bills.Include(b => b.Supplier)
            .Include(b => b.BillItems)
            .Where(b => b.SupplierId == supplierId)
            .OrderByDescending(b => b.BillDate)
            .ToListAsync();

        return _mapper.Map<List<BillDto>>(bills);
    }
}
