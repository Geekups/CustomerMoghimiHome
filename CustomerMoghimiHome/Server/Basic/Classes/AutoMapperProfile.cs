using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;

namespace CustomerMoghimiHome.Server.Basic.Classes;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductCategoryEntity, ProductCategoryDto>().ReverseMap();
    }
}