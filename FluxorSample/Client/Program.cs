using Fluxor;
using FluxorSample.Client;
using FluxorSample.Client.Features.Loading;
using FluxorSample.Client.Features.WeatherForecast;
using FluxorSample.Client.Middlewares;
using FluxorSample.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddFluxor(o => o
    .ScanAssemblies(typeof(Program).Assembly)
    .UseRouting()
    .AddMiddleware<LoggingMiddleware>());
builder.Services.AddSingleton<LoadingStateService>();

await builder.Build().RunAsync();
