using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Data.Interfaces;
using Infrastructure.Filters;
using Infrastructure.Helpers;
using Infrastructure.Extensions;
using Catalog.Host.Configurations;
using Catalog.Host.Data;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpGlobalExceptionFilter>();
    options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseRouteTransformer()));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddBaseConfiguration();
builder.Services.Configure<CatalogConfiguration>(configuration.GetSection("Api"));

builder.Services.AddTransient<ICatalogItemRepository, CatalogItemRepository>();
builder.Services.AddTransient<ICatalogBrandRepository, CatalogBrandRepository>();
builder.Services.AddTransient<ICatalogTypeRepository, CatalogTypeRepository>();
builder.Services.AddTransient<ICatalogItemService, CatalogItemService>();
builder.Services.AddTransient<ICatalogBrandService, CatalogBrandService>();
builder.Services.AddTransient<ICatalogTypeService, CatalogTypeService>();

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IApplicationDbContextWrapper<ApplicationDbContext>, ApplicationDbContextWrapper<ApplicationDbContext>>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        corsPolicyBuilder => corsPolicyBuilder
            .SetIsOriginAllowed((host) => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
        );
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint($"{configuration["BaseUrl"]}/swagger/v1/swagger.json", "Catalog.API V1");
    //options.OAuthClientId("catalog_swagger_ui");
    //options.OAuthAppName("Catalog Swagger UI");
});

app.UseRouting();
app.UseCors("CorsPolicy");

//app.UseAuthentication();
//app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapControllers();

DbInitializer.Init(app);

app.Run();