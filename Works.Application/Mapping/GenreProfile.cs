using AutoMapper;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;

namespace FavoriteLiterature.Works.Application.Mapping;

public sealed class GenreProfile : Profile
{
    public GenreProfile()
    {
        CreateMap<CreateGenreCommand, Genre>();
    }
}