using AccountingPro.Application.DTOs;
using AccountingPro.Core.Entities;

namespace AccountingPro.Application.Services;

public interface IPaymentService
{
    Task<List<PaymentDto>> GetPaymentsByCompanyAsync(int companyId);
    Task<PaymentDto?> GetPaymentByIdAsync(int id);
    Task<Payment> CreatePaymentAsync(CreatePaymentReceiptDto dto, int companyId);
    Task<Payment> CreateCashSaleAsync(CashSaleDto dto, int companyId);
    Task DeletePaymentAsync(int id);
    Task<string> GeneratePaymentNumberAsync(int companyId);
}
