using CustomerMoghimiHome.Shared.EntityFramework.Common;
using System.ComponentModel.DataAnnotations;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class ProductDto : BaseDto
{
    [Required(ErrorMessage = "لطفا نام محصول را وارد کنید.")]
    public string ProductName { get; set; }
    [Required(ErrorMessage = "لطفا نام قیمت محصول را وارد کنید.")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "لطفا نام شرکت سازنده محصول را وارد کنید.")]
    public string BuilderCompany { get; set; }
    [Required(ErrorMessage = "لطفا نام توضیحات بندی محصول را وارد کنید.")]
    public string ProductDescription { get; set; }
    [Required(ErrorMessage = "لطفا نام عکس محصول را وارد کنید.")]
    public string ImagePath { get; set; }
    public string ImageAlt { get; set; }
    public string Tags { get; set; }
    public bool IsSuggested { get; set; }
    public long ProductCategoryEntityId { get; set; }
    public ProductCategoryDto ProductCategory { get; set; }
}
