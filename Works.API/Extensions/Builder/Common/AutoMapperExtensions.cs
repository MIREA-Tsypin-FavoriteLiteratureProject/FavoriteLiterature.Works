using AutoMapper;
using FavoriteLiterature.Works.Application.Mapping;

namespace FavoriteLiterature.Works.Extensions.Builder.Common;

public static class AutoMapperExtensions
{
    public static void AddAutoMapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IMapper>(_ => { var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AttachmentProfile());
                cfg.AddProfile(new AuthorProfile());
                cfg.AddProfile(new GenreProfile());
                cfg.AddProfile(new WorkProfile());
            });

            return config.CreateMapper();
        });
    }
}