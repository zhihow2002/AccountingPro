using AccountingPro.Application.DTOs;
using AccountingPro.Core.Entities;
using AutoMapper;

namespace AccountingPro.Application.Mappings;

public class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<Invoice, InvoiceDto>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
            .ForMember(dest => dest.OutstandingAmount, opt => opt.MapFrom(src => src.BalanceAmount))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.InvoiceItems));

        CreateMap<InvoiceItem, InvoiceItemDto>()
            .ForMember(
                dest => dest.ProductName,
                opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : "")
            )
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId ?? 0))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.LineTotal))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => (int)src.Quantity));

        CreateMap<CreateInvoiceDto, Invoice>();
        CreateMap<CreateInvoiceItemDto, InvoiceItem>();
    }
}
