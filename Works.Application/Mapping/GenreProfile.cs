using AutoMapper;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;
using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;

namespace FavoriteLiterature.Works.Application.Mapping;

public sealed class GenreProfile : Profile
{
    public GenreProfile()
    {
        CreateMap<Genre, GetGenreResponse>();
        
        CreateMap<CreateGenreCommand, Genre>();
    }
}