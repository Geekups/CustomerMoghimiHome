using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;
using CustomerMoghimiHome.Server.EntityFramework.Entities.File;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Seo;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.File;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;

namespace CustomerMoghimiHome.Server.Basic.Classes;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region Shop

        CreateMap<ProductCategoryEntity, ProductCategoryDto>().ReverseMap();
        CreateMap<ProductEntity, ProductDto>().ReverseMap();
        CreateMap<PaginatedList<ProductCategoryDto>, PaginatedList<ProductCategoryEntity>>().ReverseMap();
        CreateMap<PaginatedList<ProductDto>, PaginatedList<ProductEntity>>().ReverseMap();
        CreateMap<UserBasketEntity, UserBasketDto>().ReverseMap();
        
        #endregion

        #region Seo

        CreateMap<TagEntity, TagDto>().ReverseMap();
        CreateMap<AltEntity, AltDto>().ReverseMap();
        CreateMap<PaginatedList<TagDto>, PaginatedList<TagEntity>>().ReverseMap();
        CreateMap<PaginatedList<AltDto>, PaginatedList<AltEntity>>().ReverseMap();

        #endregion

        #region File

        CreateMap<ImageEntity, ImageDto>().ReverseMap();

        #endregion

        #region Customer
        CreateMap<CustomerDetailEntity, CustomerDetailDto>().ReverseMap();
        CreateMap<ContactFormEntity, ContactFormDto>().ReverseMap();
        CreateMap<PaginatedList<ContactFormDto>, PaginatedList<ContactFormEntity>>().ReverseMap();
        #endregion
    }
}