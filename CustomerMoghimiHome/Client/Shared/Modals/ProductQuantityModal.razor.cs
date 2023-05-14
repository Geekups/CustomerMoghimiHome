using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Shared.Modals;

public partial class ProductQuantityModal
{
    [Parameter] public string ProductName { get; set; }
    [Parameter] public string ButtonText { get; set; }
    [Parameter] public long ProductId { get; set; }
    [Parameter] public int ProductCount { get; set; }
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }
    async void Submit()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        var userName = authstate.User.Identity.Name ?? "";
        var basketDetail = new BasketDetailDto()
        {
            Id = ProductId,
            UserEmail = userName,
            Quantity = ProductCount
        };
        await _httpService.PutValue(ShopRoutes.UserBasket + CRUDRouts.Update, basketDetail);
        MudDialog.Close(DialogResult.Ok(true));
    }
    void Cancel() => MudDialog.Cancel();
}
