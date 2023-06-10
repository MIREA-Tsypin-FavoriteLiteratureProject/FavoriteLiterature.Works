using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Data.Repositories.Attachments;
using FavoriteLiterature.Works.Data.Repositories.Authors;
using FavoriteLiterature.Works.Data.Repositories.Genres;
using FavoriteLiterature.Works.Data.Repositories.Works;

namespace FavoriteLiterature.Works.Extensions.Builder;

public static class RepositoryExtensions
{
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAttachmentsRepository, AttachmentsRepository>();
        builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
        builder.Services.AddScoped<IGenresRepository, GenresRepository>();
        builder.Services.AddScoped<IWorksRepository, WorksRepository>();
        
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}