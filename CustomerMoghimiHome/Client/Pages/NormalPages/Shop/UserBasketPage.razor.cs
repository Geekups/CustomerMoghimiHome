using CustomerMoghimiHome.Client.Shared.Modals;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class UserBasketPage
{
    #region Pre-Load

    List<BasketDetailDto> model = new();
    string? userName;
    protected override async Task OnParametersSetAsync()
    {
        await GetDataAsync();
    }

    int value;
    #endregion

    #region Actions
    public async Task GetDataAsync()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        userName = authstate.User.Identity.Name ?? "";
        model = await _httpService.GetValue<List<BasketDetailDto>>(ShopRoutes.UserBasket + CRUDRouts.ReadOneById + $"/{userName}");
    }
    public async Task ChangeProductQuantity(string productName, long productId, int productCount)
    {
        var parameters = new DialogParameters
        {
            { "ProductName", $"{productName}" },
            { "ProductId", productId },
            { "ProductCount", productCount },
            { "ButtonText", "ثبت تغییرات" },

        };
        var dialog = await _dialogService.ShowAsync<ProductQuantityModal>("تغییر تعداد محصول", parameters);
        var dialogResult = await dialog.Result;

        if (dialogResult.Canceled == false)
        {
            _snackbar.Add("عملیات با موفقیت انجام شد.", Severity.Success);
            await GetDataAsync();
        }
        else
        {
            _snackbar.Add("عملیات لغو شد.", Severity.Error);
        }
    }

    public void SubmitOrder()
    {
        _navigationManager.NavigateTo("/submit-order");
    }
    #endregion
}
