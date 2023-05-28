using FavoriteLiterature.Works.Application.Handlers.Genres.Commands;
using FavoriteLiterature.Works.Application.Handlers.Genres.Queries;
using FavoriteLiterature.Works.Application.Handlers.Works.Commands;
using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;
using FavoriteLiterature.Works.Domain.Genres.Requests.Queries;
using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;
using FavoriteLiterature.Works.Domain.Works.Requests.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Extensions.Builder.Common;

public static class MediatrExtensions
{
    public static void AddMediatr(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(_ => _.RegisterServicesFromAssemblies(typeof(Program).Assembly));

        #region Genre
        
        builder.Services.AddTransient<IRequestHandler<GetGenreQuery, GetGenreResponse>, GetGenreQueryHandler>();
        builder.Services.AddTransient<IRequestHandler<GetAllGenresQuery, GetAllGenresResponse>, GetAllGenresQueryHandler>();
        builder.Services.AddTransient<IRequestHandler<CreateGenreCommand, CreateGenreResponse>, CreateGenreCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<UpdateGenreCommand, UpdateGenreResponse>, UpdateGenreCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<DeleteGenreCommand, DeleteGenreResponse>, DeleteGenreCommandHandler>();

        #endregion

        #region Work

        builder.Services.AddTransient<IRequestHandler<CreateWorkCommand>, CreateWorkCommandHandler>();

        #endregion
    }
}