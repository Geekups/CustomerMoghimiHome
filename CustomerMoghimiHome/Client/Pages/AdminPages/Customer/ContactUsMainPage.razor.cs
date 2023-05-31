using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Customer;

public partial class ContactUsMainPage
{

    #region Table

    private IEnumerable<ContactFormDto> pagedData;
    private MudTable<ContactFormDto> table;
    private string searchString = "";
    private ContactFormDto selectedItem = null;
    private bool isBusy = false;

    /// <summary>
    /// getting the paged, filtered and ordered data from the server
    /// </summary>
    private async Task<TableData<ContactFormDto>> ServerReload(TableState state)
    {
        DefaultPaginationFilter paginationFilter = new(state.Page, state.PageSize);
        var paginatedData = await _httpService.GetPagedValue<ContactFormDto>(CustomerRoute.ContactForm + CRUDRouts.ReadListByFilter, paginationFilter);
        pagedData = paginatedData.Data;
        return new TableData<ContactFormDto>() { TotalItems = paginatedData.TotalCount, Items = pagedData };
    }

    #endregion

    #region Actions

    public void ShowDetail(long id)
    {
        _navigationManager.NavigateTo($"/contact-us-user-massage-detail/{id}");
    }

    #endregion

    #region Search
    private void OnSearch(string text)
    {
        searchString = text;
        table.ReloadServerData();
    }
    #endregion
}
