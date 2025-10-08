using AccountingPro.Application.DTOs;
using AccountingPro.Core.Entities;
using AutoMapper;

namespace AccountingPro.Application.Mappings;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<UpdateCustomerDto, Customer>();
    }
}
