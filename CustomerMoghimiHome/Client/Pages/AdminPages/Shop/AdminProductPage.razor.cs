using CustomerMoghimiHome.Client.Shared;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.File;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Shop;

public partial class AdminProductPage
{
    #region Pre-Load

    ProductDto model = new();

    List<ProductCategoryDto> categoryList = new();
    private long CategorySelectedValue { get; set; }
    private string ImageSelectedValue { get; set; }
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
        model.ProductCategoryEntityId = CategorySelectedValue;
        model.ImagePath = ImageSelectedValue;
        using var response = await _httpService.PostValue(ShopRoutes.Product + CRUDRouts.Create, model);
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
            { "ContentText", "آیا از حذف این آیتم مطمئن هستید؟ این عملیات قابل برگشت نیست." },
            { "ButtonText", "Delete" },
            { "Color", Color.Error }
        };
        var dialog = await _dialogService.ShowAsync<CommonDialog>("Delete", parameters);
        var dialogResult = await dialog.Result;
        if (dialogResult.Canceled == false)
        {
            using var response = await _httpService.DeleteValue(ShopRoutes.Product + CRUDRouts.Delete + $"/{id}");
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
            _snackbar.Add("عملیات لغو شد.", Severity.Error);
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
