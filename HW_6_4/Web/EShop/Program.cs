using EShop.Configurations;
using EShop.Services;
using EShop.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection("Api"));

builder.Services.AddTransient<IHttpClientService, HttpClientService>();
builder.Services.AddTransient<ICatalogService, CatalogService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "defaultError", pattern: "{controller=Error}/{action=Error}");
app.MapControllers();

app.Run();
