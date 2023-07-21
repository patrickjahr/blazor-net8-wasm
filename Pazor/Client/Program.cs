using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Pazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddHttpClient("Pazor.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Pazor.ServerAPI"));
builder.Services.AddMudServices();
builder.Services.AddSassCompiler();
builder.Services.AddScoped<TmdbService>();
await builder.Build().RunAsync();
