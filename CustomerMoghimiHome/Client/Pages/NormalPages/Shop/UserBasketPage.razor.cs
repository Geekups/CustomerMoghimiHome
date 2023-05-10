using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class UserBasketPage
{
    [Parameter] public string userName { get; set; }
    #region Pre-Load
    UserBasketDto model = new();
    
    //protected override async Task OnParametersSetAsync()
    //{
    //    model = await _httpService.GetValue<UserBasketDto>(ShopRoutes.UserBasket + CRUDRouts.ReadOneById + $"/{userName}");
    //}

    protected override async Task OnInitializedAsync()
    {
        model = await _httpService.GetValue<UserBasketDto>(ShopRoutes.UserBasket + CRUDRouts.ReadOneById + $"/{userName}");
    }
    #endregion
}
