using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.ZarinPal;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class UserFactor
{
    #region Pre-Load

    List<BasketDetailDto> model = new();
    public decimal FactorPrice { get; set; }
    protected override async Task OnInitializedAsync()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        model = await _httpService.GetValueList<BasketDetailDto>(ShopRoutes.UserBasket + CRUDRouts.ReadOneById + $"/{authstate.User.Identity.Name}");
        FactorPrice = model.Sum(x => x.ProductTotalPrice);
    }
    #endregion

    #region Actions

    protected async Task Payment()
    {
        var paymentModel = new ZarinPalRequestModel()
        {
            Amount = FactorPrice.ToString(),
            CallbackURL = "https://localhost:44345/",
            Description = "خرید از لوازم خانگی مقیمی",
            Mobile = "",
            MerchantID = ""
        };
        var response = await _httpService.PostValue(ShopRoutes.ZarinPal + CRUDRouts.RequestPayment, paymentModel);
    }
    #endregion
}
