using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net;

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

    #region Update
    public async Task Update()
    {
        using var response = await _httpService.PutValue(SeoRoutes.Alt + CRUDRouts.Update, model);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            _snackbar.Add("Operation Done Succesfully", Severity.Success);
        }
        else
        {
            _snackbar.Add("Operation Failed", Severity.Error);
        }
    }
    #endregion
}
