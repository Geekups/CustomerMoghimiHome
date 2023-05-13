using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class SubmitOrder
{
    public CustomerDetailDto model= new();

    public async Task Add()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        model.UserName = authstate.User.Identity.Name ?? "";
        await _httpService.PostValue(ShopRoutes.UserOrder + CRUDRouts.Create,  model);
    }
}
