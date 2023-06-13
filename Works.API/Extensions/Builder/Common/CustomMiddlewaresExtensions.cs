using FavoriteLiterature.Works.Middlewares;

namespace FavoriteLiterature.Works.Extensions.Builder.Common;

public static class CustomMiddlewaresExtensions
{
    public static void AddCustomMiddlewares(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ExceptionHandlingMiddleware>();
    }
}