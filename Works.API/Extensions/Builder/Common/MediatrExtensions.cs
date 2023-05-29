using FavoriteLiterature.Works.Application.Handlers.AttachmentTypes.Queries;
using FavoriteLiterature.Works.Application.Handlers.Authors.Commands;
using FavoriteLiterature.Works.Application.Handlers.Authors.Queries;
using FavoriteLiterature.Works.Application.Handlers.Genres.Commands;
using FavoriteLiterature.Works.Application.Handlers.Genres.Queries;
using FavoriteLiterature.Works.Application.Handlers.Works.Commands;
using FavoriteLiterature.Works.Domain.AttachmentTypes.Requests.Queries;
using FavoriteLiterature.Works.Domain.AttachmentTypes.Responses.Queries;
using FavoriteLiterature.Works.Domain.Authors.Requests.Commands;
using FavoriteLiterature.Works.Domain.Authors.Requests.Queries;
using FavoriteLiterature.Works.Domain.Authors.Responses.Commands;
using FavoriteLiterature.Works.Domain.Authors.Responses.Queries;
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

        #region AttachmentType

        builder.Services.AddTransient<IRequestHandler<GetAllAttachmentTypesQuery, GetAllAttachmentTypesResponse>, GetAllAttachmentTypesQueryHandler>();

        #endregion

        #region Author

        builder.Services.AddTransient<IRequestHandler<GetAuthorQuery, GetAuthorResponse>, GetAuthorQueryHandler>();
        builder.Services.AddTransient<IRequestHandler<GetAllAuthorsQuery, GetAllAuthorsResponse>, GetAllAuthorsQueryHandler>();
        builder.Services.AddTransient<IRequestHandler<CreateAuthorCommand, CreateAuthorResponse>, CreateAuthorCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<UpdateAuthorCommand, UpdateAuthorResponse>, UpdateAuthorCommandHandler>();

        #endregion
        
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