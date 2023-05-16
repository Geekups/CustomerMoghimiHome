using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class UserFactor
{
	#region Pre-Load

	List<UserBasketDto> model = new();
    public decimal FactorPrice { get; set; }
    protected override async Task OnInitializedAsync()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        model = await _httpService.GetValueList<UserBasketDto>(ShopRoutes.UserBasket + CRUDRouts.ReadOneById + $"/{authstate.User.Identity.Name}");
        FactorPrice = model.Sum(x => x.ProductTotalPrice);
    }
    #endregion
}
