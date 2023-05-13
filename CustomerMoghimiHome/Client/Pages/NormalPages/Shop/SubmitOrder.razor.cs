using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class SubmitOrder
{
    #region Pre-Load
    public CustomerDetailDto model = new();
    #endregion

    #region Actions
    public async Task Add()
    {
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        model.UserName = authstate.User.Identity.Name ?? "";
        await _httpService.PostValue(ShopRoutes.UserOrder + CRUDRouts.Create, model);
    }
    #endregion

    #region Table

    private IEnumerable<ProductDto> pagedData;
    private MudTable<ProductDto> table;

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
}
