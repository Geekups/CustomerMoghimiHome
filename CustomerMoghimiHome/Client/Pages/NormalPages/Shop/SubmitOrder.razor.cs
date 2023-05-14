using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class SubmitOrder
{
    #region Pre-Load
    public CustomerDetailDto model = new();
    #endregion

    #region Actions
    public async Task Add()
    {
        await _httpService.PostValue(ShopRoutes.UserOrder + CRUDRouts.Create, model);
    }
    #endregion

    #region Table

    private IEnumerable<UserOrderDto> Data { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        model.UserName = authstate.User.Identity.Name ?? "";

        Data = await _httpService.GetValueList<UserOrderDto>(ShopRoutes.UserOrder + CRUDRouts.CustomReadList + $"/{model.UserName}");
    }


    #endregion
}
