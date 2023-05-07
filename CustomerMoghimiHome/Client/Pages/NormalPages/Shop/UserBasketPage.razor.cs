using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class UserBasketPage
{
    List<BasketDto> model = new();
    string userName = "";

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        var name = authstate.User.Identity.Name;
        model = await _httpService.GetValueList<BasketDto>(BasketRoutes.Basket + CRUDRouts.ReadAll + userName);
    }
}
