using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Shop;

public partial class EditPrudoct
{
    #region Pre-Load
    [Parameter] public string Id { get; set; }
    ProductDto model = new();
    List<ProductCategoryDto> categoryList = new();
    private long CategorySelectedValue { get; set; }

    protected override async Task OnInitializedAsync()
    {
        categoryList = await _httpService.GetValueList<ProductCategoryDto>(ShopRoutes.ProductCategory + CRUDRouts.ReadAll);
        model = await _httpService.GetValue<ProductDto>(ShopRoutes.Product + CRUDRouts.ReadOneById + $"/{Id}");
    }
    #endregion

    #region Update
    public async Task Update()
    {
        var response = await _httpService.PutValue(ShopRoutes.Product + CRUDRouts.Update, model);
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
