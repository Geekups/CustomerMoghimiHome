using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Auth
{
    public partial class Login
    {
        private LoginModelDto loginModelDto = new LoginModelDto();

        public bool ShowAuthError { get; set; }
        public string? Error { get; set; }
        bool PasswordVisibility;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        public async Task ExecuteLogin()
        {
            ShowAuthError = false;
            var result = await _authenticationService.Login(loginModelDto);
            if (!result.IsAuthSuccessful)
            {
                _snackbar.Add("Authentication Error! Please Fill Inputs Correctly", Severity.Error);
            }
            else
            {
                _snackbar.Add("Wellcome, you are navigating to home page", Severity.Success);
                NavigationManager.NavigateTo("/");
            }
        }
        void TogglePasswordVisibility()
        {
            if (PasswordVisibility)
            {
                PasswordVisibility = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                PasswordVisibility = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }
    }
}
