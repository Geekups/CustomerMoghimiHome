using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Components;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class ProductMainPage
{
    [Parameter]
    public int ProductCategoryId { get; set; }
    List<ProductDto> model = new();
    private int _selected = 1;
    private int _totalPagesCount = 3;
    protected override async Task OnInitializedAsync()
    {
        await GetDataAsync();
    }

    private async Task GetDataAsync()
    {
        DefaultPaginationFilter paginationFilter = new(_selected, 10)
        {
            LongValue = ProductCategoryId
        };
        var paginatedData = await _httpService.GetPagedValue<ProductDto>(ShopRoutes.Product + CRUDRouts.ReadListByFilter, paginationFilter);
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
        _navigationManager.NavigateTo($"/product-detail-page/{id}");
    }
}
