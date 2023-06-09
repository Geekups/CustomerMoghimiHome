using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.File;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Shop;

public partial class EditProductCategory
{
    #region Pre-Load

    List<ImageDto> imagesList = new();
    private string ImageSelectedValue { get; set; }
    [Parameter] public string Id { get; set; }
    ProductCategoryDto model = new();
    List<TagDto> tagList = new();
    private string value { get; set; } = "Nothing selected";
    private IEnumerable<string> options { get; set; } = new HashSet<string>();
    protected override async Task OnParametersSetAsync()
    {
        imagesList = await _httpService.GetValueList<ImageDto>(FileRoutes.GetAllImageFile);
        model = await _httpService.GetValue<ProductCategoryDto>(ShopRoutes.ProductCategory + CRUDRouts.ReadOneById + $"/{Id}");
        tagList = await _httpService.GetValueList<TagDto>(SeoRoutes.Tag + CRUDRouts.ReadAll);
        options = model.Tags.Split(",").ToList();
    }
    #endregion

    #region Actions
    #region Update
    public async Task Update()
    {
        model.ImagePath = ImageSelectedValue;
        using var response = await _httpService.PutValue(ShopRoutes.ProductCategory + CRUDRouts.Update, model);
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
