using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace CustomerMoghimiHome.Client;

public partial class App
{
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await _authenticationStateProvider.GetAuthenticationStateAsync();
    }
}
