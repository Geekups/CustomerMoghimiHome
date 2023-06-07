using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class ProductMainPage
{
    #region Pre-Load
    [Parameter] public string ProductCategoryId { get; set; }
    List<ProductDto> model = new();
    private int _selected = 1;
    private int _totalPagesCount = 3;
    private string _searchText { get; set; }
    protected async override Task OnParametersSetAsync()
    {
        await GetDataAsync();
    }

    private async Task GetDataAsync()
    {
        DefaultPaginationFilter paginationFilter = new(_selected, 10)
        {
            StringValue = ProductCategoryId,
            Keyword = _searchText
        };
        var paginatedData = await _httpService.GetPagedValue<ProductDto>(ShopRoutes.Product + CRUDRouts.ReadListByFilter, paginationFilter);
        model = paginatedData.Data;
        _totalPagesCount = paginatedData.TotalPages;
        this.StateHasChanged();
    }
    #endregion

    #region Actions
    private async Task OnPageChange(int pageNumber)
    {
        _selected = pageNumber;
        await GetDataAsync();
    }

    private void OnReadMoreButtonClicked(long id)
    {
        _navigationManager.NavigateTo($"/product-detail-page/{id}");
    }

    private async Task OnFilterButtonClicked()
    {
        await GetDataAsync();
    }
    #endregion
}