using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class SubmitOrder
{
    public CustomerDetailDto model= new();

    public async Task Add()
    {
        await _httpService.PostValue("",  model);
    }
}
