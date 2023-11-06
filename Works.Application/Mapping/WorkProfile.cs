using AutoMapper;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Domain.Works.Responses.Queries;

namespace FavoriteLiterature.Works.Application.Mapping;

public sealed class WorkProfile : Profile
{
    public WorkProfile()
    {
        CreateMap<Work, GetWorkResponse>()
            .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src => src.Attachments.Select(a => a.Id).ToList()));
        CreateMap<Work, GetAllWorksItemResponse>()
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(a => a.NickName).ToList()))
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => g.Name).ToList()));
    }
}