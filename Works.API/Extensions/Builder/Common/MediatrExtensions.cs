using FavoriteLiterature.Works.Application.Handlers.Genres.Commands;
using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;
using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Extensions.Builder.Common;

public static class MediatrExtensions
{
    public static void AddMediatr(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(_ => _.RegisterServicesFromAssemblies(typeof(Program).Assembly));

        #region Genre
        
        builder.Services.AddTransient<IRequestHandler<CreateGenreCommand, CreateGenreResponse>, CreateGenreCommandHandler>();

        #endregion
    }
}