using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.File;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Shop;

public partial class EditProductCategory
{
    #region Pre-Load

    List<ImageDto> imagesList = new();
    private long ImageSelectedValue { get; set; }
    [Parameter] public string Id { get; set; }
    ProductCategoryDto model = new();
    protected override async Task OnParametersSetAsync()
    {
        imagesList = await _httpService.GetValueList<ImageDto>(FileRoutes.GetAllImageFile);
        model = await _httpService.GetValue<ProductCategoryDto>(ShopRoutes.ProductCategory + CRUDRouts.ReadOneById + $"/{Id}");
    }
    #endregion

    #region Update
    public async Task Update()
    {
        using var response = await _httpService.PutValue(ShopRoutes.ProductCategory + CRUDRouts.Update, model);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            _snackbar.Add("Operation Done Succesfully", Severity.Success);
        }
        else
        {
            _snackbar.Add("Operation Failed", Severity.Error);
        }
    }
    #endregion
}
