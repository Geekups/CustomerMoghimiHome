using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class UserBasketPage
{
    List<BasketDto> model = new();
    protected override async Task OnInitializedAsync()
    {
        model = await _httpService.GetValueList<BasketDto>(BasketRoutes.Basket + CRUDRouts.ReadAll);
    }
}
