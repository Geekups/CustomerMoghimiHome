using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Seo;

public partial class EditTag
{
    #region Pre-Load
    [Parameter] public string Id { get; set; }
    TagDto model = new();
    protected override async Task OnParametersSetAsync()
    {
        model = await _httpService.GetValue<TagDto>(SeoRoutes.Tag + CRUDRouts.ReadOneById + $"/{Id}");
    }
    #endregion

    #region Update
    public async Task Update()
    {
        using var response = await _httpService.PutValue(SeoRoutes.Tag + CRUDRouts.Update, model);
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
