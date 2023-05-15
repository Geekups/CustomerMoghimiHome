using CustomerMoghimiHome.Shared.EntityFramework.DTO.Identity;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Auth;
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
            _snackbar.Add("خطای احراز هویت! لطفا اطلاعات را به درستی وارد کنید.", Severity.Error);
        }
        else
        {
            _snackbar.Add("خوش آمدید! شما در حال انتقال به صفحه اصلی هستید.", Severity.Success);
            _navigationManager.NavigateTo("/");
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