using CustomerMoghimiHome.Client.Shared;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Seo;

public partial class AdminTagPage
{
    #region Table

    private IEnumerable<TagDto> pagedData;
    private MudTable<TagDto> table;
    private string searchString = "";
    private TagDto selectedItem = null;
    private bool isBusy = false;

    /// <summary>
    /// getting the paged, filtered and ordered data from the server
    /// </summary>
    private async Task<TableData<TagDto>> ServerReload(TableState state)
    {
        DefaultPaginationFilter paginationFilter = new(state.Page, state.PageSize);
        var paginatedData = await _httpService.GetPagedValue<TagDto>(SeoRoutes.Tag + CRUDRouts.ReadListByFilter, paginationFilter);
        pagedData = paginatedData.Data;
        return new TableData<TagDto>() { TotalItems = paginatedData.TotalCount, Items = pagedData };
    }

    #endregion

    #region Actions
    #region Add
    TagDto model = new();
    public async Task Add()
    {
        using var response = await _httpService.PostValue(SeoRoutes.Tag + CRUDRouts.Create, model);
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

    #region Delete
    private async Task OnDelete(long id)
    {
        var parameters = new DialogParameters
        {
            { "ContentText", "آیا از حذف این آیتم مطمئن هستید؟ این عملیات قابل برگشت نیست." },
            { "ButtonText", "حذف" },
            { "Color", Color.Error }
        };
        var dialog = await _dialogService.ShowAsync<CommonDialog>("Delete", parameters);
        var dialogResult = await dialog.Result;
        if (dialogResult.Canceled == false)
        {
            using var response = await _httpService.DeleteValue(SeoRoutes.Tag + CRUDRouts.Delete + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                _snackbar.Add("عملیات با موفقیت انجام شد.", Severity.Success);
            }
            else
            {
                _snackbar.Add("خطایی رخ داده لطفا فیلد ها را به درستی پرکنید. درصورت خطای مجدد لطفا با ادمین تماس بگیرید.", Severity.Error);
            }
        }
        else
        {
            _snackbar.Add("عملیات لغو شد.", Severity.Info);

        }
    }
    #endregion

    #region Search
    private void OnSearch(string text)
    {
        searchString = text;
        table.ReloadServerData();
    }
    #endregion

    #region Edit
    private void Edit(long id)
    {
        _navigationManager.NavigateTo($"/tag-alt-taggat/{id}");
    }
    #endregion
    #endregion
}
