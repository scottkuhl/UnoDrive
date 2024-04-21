using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using UnoDrive;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddSingleton<AppJs>();
builder.Services.AddScoped<AppState>();

#if DEBUG
builder.Logging.SetMinimumLevel(LogLevel.Information);
#else
builder.Logging.SetMinimumLevel(LogLevel.Warning);
#endif

await builder.Build().RunAsync();