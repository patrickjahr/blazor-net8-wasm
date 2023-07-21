using MudBlazor.Services;
using Pazor.Client.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("Pazor.ServerAPI", client => client.BaseAddress = new Uri("https://localhost:7019"));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Pazor.ServerAPI"));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services
    .AddRazorComponents()
    .AddWebAssemblyComponents();

builder.Services.AddMudServices();
builder.Services.AddSassCompiler();
builder.Services.AddScoped<TmdbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapRazorComponents<Pazor.Client.Host>()
    .AddWebAssemblyRenderMode();

app.Run();
