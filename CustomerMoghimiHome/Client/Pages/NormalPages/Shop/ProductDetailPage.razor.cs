using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.Basic.Services;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class ProductDetailPage
{
    #region Pre-Load
    ProductDto model = new();
    string userName = "";
    [Parameter] public string Id { get; set; }
    protected override async Task OnParametersSetAsync()
    {
        model = await _httpService.GetValue<ProductDto>(ShopRoutes.Product + CRUDRouts.ReadOneById + $"/{Id}");
    }
    protected async override Task OnInitializedAsync()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        userName = authstate.User.Identity.Name ?? "";
    }
    #endregion


    #region Actions

    public async Task AddToBasket()
    {
        BasketDto basket = new BasketDto()
        {
            UserName = userName,
            ProductId = model.Id
        };
        await _httpService.PostValue(BasketRoutes.Basket + CRUDRouts.Create, basket);
    }

    #endregion
}
