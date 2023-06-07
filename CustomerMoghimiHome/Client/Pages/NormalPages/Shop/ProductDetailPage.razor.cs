using CustomerMoghimiHome.Client.Shared;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class ProductDetailPage
{
    #region Pre-Load
    ProductDto model = new();
    string userName = "";
    [Parameter] public string Id { get; set; }
    protected override async Task OnParametersSetAsync()
    {
        model = await _httpService.GetValue<ProductDto>(ShopRoutes.Product + CRUDRouts.ReadOneById + $"/{Id}");
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        userName = authstate.User.Identity.Name ?? "";
    }
    #endregion

    #region Actions
    public async Task AddToBasketAsync()
    {
        UserBasketDto basketModel = new()
        {
            SelectedProductId = model.Id,
            UserName = userName,
            ProductName = model.ProductName,
            ProductPrice = model.Price,
            IsOrdered = false,
            ProductId = model.Id
        };
        using var response = await _httpService.PostValue(ShopRoutes.UserBasket + CRUDRouts.Create, basketModel);
        if (response.IsSuccessStatusCode)
        {
            _snackbar.Add("یک آیتم به سبد خرید شما اضافه شد!", Severity.Success);
        }
        else
        {
            _snackbar.Add("خطایی رخ داده لطفا صفحه را دوباره لود کنید. درصورت خطای مجدد لطفا با ادمین تماس بگیرید.", Severity.Error);
        }
    }
    public async Task NotAuthorized()
    {
        var parameters = new DialogParameters
        {
            { "ContentText", "برای افزودن موارد جدید و یا ایجاد سبد خرید باید اول وارد اکانت خود شوید." },
            { "ButtonText", "ورود/ساخت اکانت" },
            { "Color", Color.Success }
        };
        var dialog = await _dialogService.ShowAsync<CommonDialog>("NotAuthorized", parameters);
        var dialogResult = await dialog.Result;
        if (dialogResult.Canceled == false)
        {
            _navigationManager.NavigateToLogin("/login");
            _snackbar.Add("انتقال به صفحه ورود", Severity.Info);
        }
        else
        {
            _snackbar.Add("عملیات لغو شد", Severity.Warning);

        }
    }
    #endregion
}
