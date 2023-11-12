using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Infrastructure.Filters;
using Infrastructure.Helpers;
using Infrastructure.Extensions;
using Basket.Host.Services;
using Basket.Host.Services.Interfaces;
using Basket.Host.Configurations;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpGlobalExceptionFilter>();
    options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseRouteTransformer()));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddBaseConfiguration();
builder.Services.Configure<RedisConfiguration>(configuration.GetSection("Redis"));

//builder.Services.AddAuthorization(configuration);

builder.Services.AddTransient<IRedisCacheConnectionService, RedisCacheConnectionService>();
builder.Services.AddTransient<ICacheService, CacheService>();
builder.Services.AddTransient<IBasketService, BasketService>();

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
    options.SwaggerEndpoint($"{configuration["Api:BaseUrl"]}/swagger/v1/swagger.json", "Basket.API V1");
    //options.OAuthClientId("basket_swagger_ui");
    //options.OAuthAppName("Basket Swagger UI");
});

app.UseRouting();
app.UseCors("CorsPolicy");

//app.UseAuthentication();
//app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapControllers();

app.Run();
