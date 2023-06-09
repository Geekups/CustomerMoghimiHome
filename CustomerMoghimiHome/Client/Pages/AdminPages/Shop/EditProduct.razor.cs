using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.File;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Shop;

public partial class EditProduct
{
    #region Pre-Load
    private string ImageSelectedValue { get; set; }
    List<ImageDto> imagesList = new();

    [Parameter] public string Id { get; set; }
    ProductDto model = new();
    List<ProductCategoryDto> categoryList = new();
    private long CategorySelectedValue { get; set; }
    List<TagDto> tagList = new();
    private string value { get; set; } = "Nothing selected";
    private IEnumerable<string> options { get; set; } = new HashSet<string>();
    protected override async Task OnParametersSetAsync()
    {
        categoryList = await _httpService.GetValueList<ProductCategoryDto>(ShopRoutes.ProductCategory + CRUDRouts.ReadAll);
        model = await _httpService.GetValue<ProductDto>(ShopRoutes.Product + CRUDRouts.ReadOneById + $"/{Id}");
        imagesList = await _httpService.GetValueList<ImageDto>(FileRoutes.GetAllImageFile);
        tagList = await _httpService.GetValueList<TagDto>(SeoRoutes.Tag + CRUDRouts.ReadAll);
        options = model.Tags.Split(",").ToList();
    }
    #endregion

    #region Actions
    #region Update
    public async Task Update()
    {
        model.ImagePath = ImageSelectedValue;
        model.ProductCategoryEntityId = CategorySelectedValue;
        using var response = await _httpService.PutValue(ShopRoutes.Product + CRUDRouts.Update, model);
        if (response.IsSuccessStatusCode)
        {
            _snackbar.Add("عملیات با موفقیت انجام شد.", Severity.Success);
        }
        else
        {
            _snackbar.Add("خطایی رخ داده لطفا فیلد ها را به درستی پرکنید. درصورت خطای مجدد لطفا با ادمین تماس بگیرید.", Severity.Error);
        }
    }
    #endregion
    #endregion
}
