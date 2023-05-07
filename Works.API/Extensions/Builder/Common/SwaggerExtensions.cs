namespace FavoriteLiterature.Works.Extensions.Builder.Common;

public static class SwaggerExtensions
{
    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
    }
}