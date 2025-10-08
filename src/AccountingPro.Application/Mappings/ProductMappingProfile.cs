using AccountingPro.Application.DTOs;
using AccountingPro.Core.Entities;
using AutoMapper;

namespace AccountingPro.Application.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.SKU))
            .ForMember(dest => dest.SalesPrice, opt => opt.MapFrom(src => src.SalePrice))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.SalePrice)) // Using SalePrice as UnitPrice for now
            .ForMember(dest => dest.PurchasePrice, opt => opt.MapFrom(src => src.CostPrice))
            .ForMember(dest => dest.CostPerUnit, opt => opt.MapFrom(src => src.CostPrice))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => "Product")) // Default to Product
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsActive ? "Active" : "Inactive"))
            .ForMember(dest => dest.TaxRate, opt => opt.MapFrom(src => 0m)); // Default tax rate

        CreateMap<CreateProductDto, Product>()
            .ForMember(dest => dest.SKU, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.SalesPrice))
            .ForMember(dest => dest.CostPrice, opt => opt.MapFrom(src => src.PurchasePrice))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));

        CreateMap<UpdateProductDto, Product>()
            .ForMember(dest => dest.SKU, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.SalesPrice))
            .ForMember(dest => dest.CostPrice, opt => opt.MapFrom(src => src.PurchasePrice));
    }
}