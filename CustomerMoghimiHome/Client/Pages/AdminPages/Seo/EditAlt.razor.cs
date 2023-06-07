using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Seo;

public partial class EditAlt
{
    #region Pre-Load
    [Parameter] public string Id { get; set; }
    AltDto model = new();
    protected override async Task OnParametersSetAsync()
    {
        model = await _httpService.GetValue<AltDto>(SeoRoutes.Alt + CRUDRouts.ReadOneById + $"/{Id}");
    }
    #endregion

    #region Actions
    #region Update
    public async Task Update()
    {
        using var response = await _httpService.PutValue(SeoRoutes.Alt + CRUDRouts.Update, model);
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
    #endregion
}
