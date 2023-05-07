using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class UserBasketPage
{
    List<BasketDto> model = new();
    [Parameter]
    public string userName { get; set; }

    protected async override Task OnParametersSetAsync()
    {
        model = await _httpService.GetValueList<BasketDto>(BasketRoutes.Basket + CRUDRouts.ReadAll + $"/{userName}");
    }
}
