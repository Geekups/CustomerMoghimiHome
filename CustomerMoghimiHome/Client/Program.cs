using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress);
await builder.Build().RunAsync();

static void ConfigureServices(IServiceCollection services, string baseAddress)
{
    services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
}