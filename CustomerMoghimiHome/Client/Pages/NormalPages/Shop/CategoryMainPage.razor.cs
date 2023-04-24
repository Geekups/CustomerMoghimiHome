using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components.Routing;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class CategoryMainPage
{
    List<ProductCategoryDto> model = new();
    private int _selected = 1;
    private int _totalPagesCount = 3;
    protected override async Task OnInitializedAsync()
    {
        await GetDataAsync();
    }

    private async Task GetDataAsync()
    {
        DefaultPaginationFilter paginationFilter = new(_selected, 10);
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
        _navigationManager.NavigateTo($"/blog-post-page/{id}");
    }
}
