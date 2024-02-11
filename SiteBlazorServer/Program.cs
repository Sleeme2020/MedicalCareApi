using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SiteBlazorServer.Data;
using SiteBlazorServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<DiseaseProxyType>();
builder.Services.AddScoped<DiseaseProxy>();

builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
