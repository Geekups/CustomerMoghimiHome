using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class CategoryMainPage
{
    #region Pre-Load
    List<ProductCategoryDto> model = new();
    private int _selected = 1;
    private int _totalPagesCount = 3;
    private string _searchText { get; set; }
    protected override async Task OnInitializedAsync()
    {
        await GetDataAsync();
    }
    #endregion
    #region Actions

    private async Task GetDataAsync()
    {
        DefaultPaginationFilter paginationFilter = new(_selected, 10)
        {
            Keyword = _searchText,
        };
        var paginatedData = await _httpService.GetPagedValue<ProductCategoryDto>(ShopRoutes.ProductCategory + CRUDRouts.ReadListByFilter, paginationFilter);
        model = paginatedData.Data;
        _totalPagesCount = paginatedData.TotalPages;
        this.StateHasChanged();
    }

    private async Task OnPageChange(int pageNumber)
    {
        _selected = pageNumber;
        await GetDataAsync();
    }

    private void OnReadMoreButtonClicked(long id)
    {
        _navigationManager.NavigateTo($"/products-page/{id}");
    }

    private async Task OnFilterButtonClicked()
    {
        await GetDataAsync();
    }
    #endregion
}
