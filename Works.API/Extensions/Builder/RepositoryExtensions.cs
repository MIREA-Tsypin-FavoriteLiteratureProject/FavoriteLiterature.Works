using Works.Data.Repositories.Attachments;
using Works.Data.Repositories.AttachmentTypes;
using Works.Data.Repositories.Authors;
using Works.Data.Repositories.Genres;
using Works.Data.Repositories.Works;

namespace Works.API.Extensions.Builder;

public static class RepositoryExtensions
{
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAttachmentsRepository, AttachmentsRepository>();
        builder.Services.AddScoped<IAttachmentTypesRepository, AttachmentTypesRepository>();
        builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
        builder.Services.AddScoped<IGenresRepository, GenresRepository>();
        builder.Services.AddScoped<IWorksRepository, WorksRepository>();
    }
}