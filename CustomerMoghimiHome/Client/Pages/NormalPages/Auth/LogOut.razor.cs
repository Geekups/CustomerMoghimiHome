using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Auth;
public partial class LogOut
{
    #region Actions
    protected override async Task OnInitializedAsync()
    {
        await _authenticationService.Logout();
        _snackbar.Add("شما خارج شدید و در حال انتقال به صفحه اصلی هستید.", Severity.Success);
        _navigationManager.NavigateTo("/");
        await _sessionStorageService.ClearAsync();
    }
    #endregion
}