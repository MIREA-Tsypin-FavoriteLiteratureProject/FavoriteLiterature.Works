using Microsoft.OpenApi.Models;

namespace FavoriteLiterature.Works.Extensions.Builder.Common;

public static class SwaggerExtensions
{
    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            // Дополнительная информация для генерации документации.
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Favorite literature Works.API",
                Description = "Сервис книжный магазин",
                Contact = new OpenApiContact
                {
                    Name = "Цыпин Илья Павлович",
                    Email = "some_email@mail.ru",
                    Url = new Uri("https://t.me/some_email"),
                },
            });
        });
    }
}