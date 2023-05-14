using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using MudBlazor;
using System.Net;
using System.Net.WebSockets;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class SubmitOrder
{
    #region Pre-Load
    public CustomerDetailDto model = new();
    protected override async Task OnInitializedAsync()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        model.UserName = authstate.User.Identity.Name ?? "";
    }
    #endregion

    #region Actions
    public async Task Add()
    {
       var response = await _httpService.PostValue(ShopRoutes.UserOrder + CRUDRouts.Create, model);
        if (response.IsSuccessStatusCode)
        {
            _snackbar.Add("Operation Done Successfully", Severity.Success);
            _navigationManager.NavigateTo("/user-shopping-factor");
        }
        else
        {
            _snackbar.Add("Operation Failed", Severity.Error);
        }
    }
    #endregion

}
