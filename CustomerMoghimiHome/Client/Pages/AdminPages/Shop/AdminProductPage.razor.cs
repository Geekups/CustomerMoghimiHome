using CustomerMoghimiHome.Client.Shared;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.File;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using MudBlazor;
using System.Net;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Shop;

public partial class AdminProductPage
{
    #region Pre-Load

    ProductDto model = new();
    private IEnumerable<long> options { get; set; } = new HashSet<long>();

    List<ProductCategoryDto> categoryList = new();
    private long CategorySelectedValue { get; set; }

    List<ImageDto> imagesList = new();


    protected override async Task OnParametersSetAsync()
    {
        imagesList = await _httpService.GetValueList<ImageDto>(FileRoutes.GetAllImageFile);
    }

    protected override async Task OnInitializedAsync()
    {
        categoryList = await _httpService.GetValueList<ProductCategoryDto>(ShopRoutes.ProductCategory + CRUDRouts.ReadAll);
    }
    #endregion

    #region Add  

    public async Task Add()
    {
        model.ProductCategoryEnityId = CategorySelectedValue;
        var response = await _httpService.PostValue(ShopRoutes.Product + CRUDRouts.Create, model);
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

    #region Table

    private IEnumerable<ProductDto> pagedData;
    private MudTable<ProductDto> table;
    private string searchString = "";
    private ProductDto selectedItem = null;
    private bool isBusy = false;

    /// <summary>
    /// getting the paged, filtered and ordered data from the server
    /// </summary>
    private async Task<TableData<ProductDto>> ServerReload(TableState state)
    {
        DefaultPaginationFilter paginationFilter = new(state.Page, state.PageSize);
        var paginatedData = await _httpService.GetPagedValue<ProductDto>(ShopRoutes.Product + CRUDRouts.ReadListByFilter, paginationFilter);
        pagedData = paginatedData.Data;
        return new TableData<ProductDto>() { TotalItems = paginatedData.TotalCount, Items = pagedData };
    }

    #endregion

    #region Delete
    private async Task OnDelete(long id)
    {
        var parameters = new DialogParameters
        {
            { "ContentText", "Do you really want to delete these record ? This process cannot be undo." },
            { "ButtonText", "Delete" },
            { "Color", Color.Error }
        };
        var dialog = await _dialogService.ShowAsync<CommonDialog>("Delete", parameters);
        var dialogResult = await dialog.Result;
        if (dialogResult.Canceled == false)
        {
            var response = await _httpService.DeleteValue(ShopRoutes.Product + CRUDRouts.Delete + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                _snackbar.Add("Operation Done Succesfully", Severity.Success);
                await table.ReloadServerData();
            }
            else
            {
                _snackbar.Add("Operation Failed", Severity.Error);
            }
        }
        else
        {
            _snackbar.Add("Operation Canceled", Severity.Warning);

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
    private async Task Edit(long id)
    {
        _navigationManager.NavigateTo($"/pppp-pp-pp-pppppppppp--edit/{id}");
    }
    #endregion
}
