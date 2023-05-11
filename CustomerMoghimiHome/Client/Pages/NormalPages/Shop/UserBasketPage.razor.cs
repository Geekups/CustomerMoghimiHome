using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class UserBasketPage
{
    #region Pre-Load
    
    List<BasketDetailDto> model = new();
    protected override async Task OnParametersSetAsync()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        var userName = authstate.User.Identity.Name ?? "";
        model = await _httpService.GetValue<List<BasketDetailDto>>(ShopRoutes.UserBasket + CRUDRouts.ReadOneById + $"/{userName}");
    }


    #endregion
}
