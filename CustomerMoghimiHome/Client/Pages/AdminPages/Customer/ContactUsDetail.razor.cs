using CustomerMoghimiHome.Client.Shared;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Customer;

public partial class ContactUsDetail
{
    #region Pre-Load
    ContactFormDto model = new();
    string userName = "";
    [Parameter] public string Id { get; set; }
    protected override async Task OnParametersSetAsync()
    {
        model = await _httpService.GetValue<ContactFormDto>(CustomerRoute.ContactForm + CRUDRouts.ReadOneById + $"/{Id}");
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        userName = authstate.User.Identity.Name ?? "";
    }
    #endregion
    #region Actions
    public async Task Delete(long id)
    {
        using var response = await _httpService.DeleteValue(CustomerRoute.ContactForm + CRUDRouts.Delete + $"/{id}");
        if (response.IsSuccessStatusCode)
        {
            if (response.IsSuccessStatusCode)
            {
                _snackbar.Add("عملیات با موفقیت انجام شد.", Severity.Success);
                _snackbar.Add("شما در حال انتقال به صفحه ادمین هستید", Severity.Info);
                _navigationManager.NavigateTo("/site-admin-panel-control-unit-unit-control-anti-dictionary-attack");
            }
            else
            {
                _snackbar.Add("خطایی رخ داده لطفا فیلد ها را به درستی پرکنید. درصورت خطای مجدد لطفا با ادمین تماس بگیرید.", Severity.Error);
            }
        }
        else
        {
            _snackbar.Add("خطایی رخ داده لطفا فیلد ها را به درستی پرکنید. درصورت خطای مجدد لطفا با ادمین تماس بگیرید.", Severity.Error);
        }
    }
    #endregion
}
