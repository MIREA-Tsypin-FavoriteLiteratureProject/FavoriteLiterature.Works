using AutoMapper;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Domain.Authors.Requests.Commands;

namespace FavoriteLiterature.Works.Application.Mapping;

public sealed class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<CreateAuthorCommand, Author>();
    }
}