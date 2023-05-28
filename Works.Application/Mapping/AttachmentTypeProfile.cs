using AutoMapper;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Domain.AttachmentTypes.Responses.Queries;

namespace FavoriteLiterature.Works.Application.Mapping;

public sealed class AttachmentTypeProfile : Profile
{
    public AttachmentTypeProfile()
    {
        CreateMap<AttachmentType, GetAllAttachmentTypesItemResponse>();
    }
}