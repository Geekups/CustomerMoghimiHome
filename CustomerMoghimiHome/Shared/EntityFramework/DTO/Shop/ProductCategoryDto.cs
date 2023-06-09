using CustomerMoghimiHome.Shared.EntityFramework.Common;
using System.ComponentModel.DataAnnotations;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class ProductCategoryDto : BaseDto
{
    [Required(ErrorMessage = "لطفا نام دسته بندی محصول را وارد کنید.")]
    public string CategoryName { get; set; }
    [Required(ErrorMessage = "لطفا توضیحات دسته بندی محصول را وارد کنید.")]
    public string CategoryDescription { get; set; }
    [Required(ErrorMessage = "لطفا عکس محصول را انتخاب کنید.")]
    public string ImagePath { get; set; }
    public string ImageAlt { get; set; }
    public string Tags { get; set; }
    public List<ProductDto> ProductList { get; set; } = new();
}
