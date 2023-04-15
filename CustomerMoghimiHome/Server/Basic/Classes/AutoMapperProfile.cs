using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;

namespace CustomerMoghimiHome.Server.Basic.Classes;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductCategoryEntity, ProductCategoryDto>().ReverseMap();
        CreateMap<ProductEntity, ProductDto>().ReverseMap();
        CreateMap<PaginatedList<ProductCategoryDto>, PaginatedList<ProductCategoryEntity>>().ReverseMap();
        CreateMap<PaginatedList<ProductDto>, PaginatedList<ProductEntity>>().ReverseMap();
    }
}