using CustomerMoghimiHome.Shared.EntityFramework.Common;
using System.ComponentModel.DataAnnotations;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class ProductCategoryDto : BaseDto
{
    [Required(ErrorMessage = "لطفا نام دسته بندی محصول را وارد کنید.")]
    public string CategoryName { get; set; } = string.Empty;
    [Required(ErrorMessage = "لطفا توضیحات دسته بندی محصول را وارد کنید.")]
    public string CategoryDescription { get; set; } = string.Empty;
    [Required(ErrorMessage = "لطفا آدرس تصویر دسته بندی محصول را وارد کنید.")]
    public string CategoryPictureAddress { get; set; } = string.Empty;

    public List<ProductDto> ProductList { get; set; } = new();
}
