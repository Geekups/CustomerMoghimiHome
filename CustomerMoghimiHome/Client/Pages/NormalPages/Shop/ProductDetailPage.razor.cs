using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class ProductDetailPage
{
    #region Pre-Load
    ProductDto model = new();

    [Parameter] public string Id { get; set; }
    protected override async Task OnParametersSetAsync()
    {
        model = await _httpService.GetValue<ProductDto>(ShopRoutes.Product + CRUDRouts.ReadOneById + $"/{Id}");
    }
    #endregion

}
