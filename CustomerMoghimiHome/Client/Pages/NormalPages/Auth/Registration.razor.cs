using CustomerMoghimiHome.Shared.EntityFramework.DTO.Identity;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Auth;
public partial class Registration
{
    #region Pre-Load
    private UserForRegistrationDto _userForRegistration = new UserForRegistrationDto();
    public bool AgreeToTerms { get; set; }

    bool PasswordVisibility;
    InputType PasswordInput = InputType.Password;
    string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
    public bool ShowRegistrationErrors { get; set; }
    public IEnumerable<string>? Errors { get; set; }
    #endregion

    #region Actions
    public async Task Register()
    {
        ShowRegistrationErrors = false;
        var result = await _authenticationService.RegisterUser(_userForRegistration);
        if (!result.IsSuccessfulRegistration)
        {
            _snackbar.Add("خطا در ثبت نام! لطفا اطلاعات را به درستی وارد کنید.", Severity.Error);
        }
        else
        {
            _snackbar.Add("خوش آمدید شما در حال انتقال به صفحه ورود می باشید.", Severity.Success);
            _navigationManager.NavigateToLogin("/login");
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
    #endregion
}