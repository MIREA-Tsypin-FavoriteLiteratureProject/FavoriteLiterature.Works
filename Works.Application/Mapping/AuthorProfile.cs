using AutoMapper;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Domain.Authors.Requests.Commands;
using FavoriteLiterature.Works.Domain.Authors.Responses.Queries;

namespace FavoriteLiterature.Works.Application.Mapping;

public sealed class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, GetAuthorResponse>();
        CreateMap<Author, GetAllAuthorsItemResponse>();

        CreateMap<CreateAuthorCommand, Author>();
    }
}