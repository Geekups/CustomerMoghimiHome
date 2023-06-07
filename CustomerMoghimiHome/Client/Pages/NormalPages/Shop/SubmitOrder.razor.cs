using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class SubmitOrder
{
    #region Pre-Load
    public CustomerDetailDto model = new();
    protected override async Task OnInitializedAsync()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        model.UserName = authstate.User.Identity.Name ?? "";
        model = await _httpService.GetValue<CustomerDetailDto>(CustomerRoute.PersonDetail + CRUDRouts.ReadOneById + $"/{authstate.User.Identity.Name}");
        if (model == null)
        {
            _snackbar.Add("لطفااطلاعات خورد را با دقت وارد کنید .", Severity.Success);
        }

    }
    #endregion

    #region Actions
    public async Task SubmitUserOrder()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        model.UserName = authstate.User.Identity.Name;
        var response = await _httpService.PostValue(CustomerRoute.PersonDetail + CRUDRouts.Create, model);
        if (response.IsSuccessStatusCode)
        {
            _snackbar.Add("عملیات با موفقیت انجام شد.", Severity.Success);
            _navigationManager.NavigateTo("/user-shopping-factor");
        }
        else
        {
            _snackbar.Add("خطایی رخ داده لطفا فیلد ها را به درستی پرکنید. درصورت خطای مجدد لطفا با ادمین تماس بگیرید.", Severity.Error);
        }
    }
    #endregion
}
