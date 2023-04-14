using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Shop;

public partial class EditProductCategoryDialog
{
    [Parameter] public long Id { get; set; }
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }
    ProductCategoryDto model = new();
    void Submit() => MudDialog.Close(DialogResult.Ok(true));
    void Cancel() => MudDialog.Cancel();
    protected override async Task OnParametersSetAsync()
    {
        model = await _httpService.GetValue<ProductCategoryDto>(ShopRoutes.ProductCategory + CRUDRouts.ReadOneById + $"/{Id}");
    }
    
    public async Task Update()
    {
        var response = await _httpService.PutValue(ShopRoutes.ProductCategory + CRUDRouts.Update, model);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            _snackbar.Add("Operation Done Succesfully", Severity.Success);
        }
        else
        {
            _snackbar.Add("Operation Failed", Severity.Error);
        }
    }

}
