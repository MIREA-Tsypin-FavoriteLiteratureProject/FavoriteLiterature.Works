using FavoriteLiterature.Works.Domain.Attachments.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Attachments.Requests.Queries;

public class GetAttachmentQuery : IRequest<GetAttachmentResponse>
{
    public Guid Id { get; }

    public GetAttachmentQuery(Guid id)
        => Id = id;
}