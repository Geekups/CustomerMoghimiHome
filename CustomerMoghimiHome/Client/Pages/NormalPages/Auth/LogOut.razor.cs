using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Auth
{
    public partial class LogOut
    {
        protected override async Task OnInitializedAsync()
        {
            await _authenticationService.Logout();
            _snackbar.Add("you are logout and navigating to home page", Severity.Success);
            NavigationManager.NavigateTo("/");
            await _sessionStorageService.ClearAsync();
        }
    }
}
