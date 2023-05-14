using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using System.Reflection;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class UserShoppingFactor
{
    #region Pre-Load
    private IEnumerable<UserOrderDto> Data { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();

        Data = await _httpService.GetValueList<UserOrderDto>(ShopRoutes.UserOrder + CRUDRouts.CustomReadList + $"/{authstate.User.Identity.Name}");
    }
    #endregion
}
