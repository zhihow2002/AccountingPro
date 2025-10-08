using AccountingPro.Application.DTOs;
using AccountingPro.Core.Entities;
using AutoMapper;

namespace AccountingPro.Application.Mappings;

public class BillMappingProfile : Profile
{
    public BillMappingProfile()
    {
        CreateMap<Bill, BillDto>()
            .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name))
            .ForMember(dest => dest.OutstandingAmount, opt => opt.MapFrom(src => src.BalanceAmount))
            .ForMember(dest => dest.LineItems, opt => opt.MapFrom(src => src.BillItems));

        CreateMap<BillItem, BillLineDto>()
            .ForMember(
                dest => dest.ProductName,
                opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : "")
            )
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId ?? 0))
            .ForMember(dest => dest.LineTotal, opt => opt.MapFrom(src => src.LineTotal))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => (int)src.Quantity));

        CreateMap<CreateBillDto, Bill>();
        CreateMap<CreateBillLineDto, BillItem>();
    }
}
