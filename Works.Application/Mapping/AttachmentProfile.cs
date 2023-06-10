using AutoMapper;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Domain.Attachments.Responses.Queries;

namespace FavoriteLiterature.Works.Application.Mapping;

public sealed class AttachmentProfile : Profile
{
    public AttachmentProfile()
    {
        CreateMap<Attachment, GetAllAttachmentsItemResponse>();
    }
}