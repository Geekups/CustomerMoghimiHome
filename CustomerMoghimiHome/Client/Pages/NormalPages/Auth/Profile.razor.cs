using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Identity;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using MudBlazor;
using System.Reflection;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Auth;

public partial class Profile
{
    #region Pre-Load
    UserDetailDto profileModel = new();
    CustomerDetailDto customerDetailModel = new();

    protected override async Task OnInitializedAsync()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        profileModel = await _httpService.GetValue<UserDetailDto>(AuthRoutes.Account + CRUDRouts.ReadOneById + $"/{authstate.User.Identity.Name}");
        customerDetailModel = await _httpService.GetValue<CustomerDetailDto>(CustomerRoute.PersonDetail + CRUDRouts.ReadOneById + $"/{authstate.User.Identity.Name}");
    }
    #endregion

    #region Actions
    public async Task UpdateProfile()
    {
        using var response = await _httpService.PostValue(AuthRoutes.Account + CRUDRouts.Create, profileModel);
        if (response.IsSuccessStatusCode)
        {
            _snackbar.Add("عملیات با موفقیت انجام شد.", Severity.Success);
        }
        else
        {
            _snackbar.Add("خطایی رخ داده لطفا فیلد ها را به درستی پرکنید. درصورت خطای مجدد لطفا با ادمین تماس بگیرید.", Severity.Error);
        }
    }

    public async Task UpdatePersonDetail()
    {
        using var response = await _httpService.PostValue(CustomerRoute.PersonDetail + CRUDRouts.Create, customerDetailModel);
        if (response.IsSuccessStatusCode)
        {
            _snackbar.Add("عملیات با موفقیت انجام شد.", Severity.Success);
        }
        else
        {
            _snackbar.Add("خطایی رخ داده لطفا فیلد ها را به درستی پرکنید. درصورت خطای مجدد لطفا با ادمین تماس بگیرید.", Severity.Error);
        }
    }
    #endregion
}
