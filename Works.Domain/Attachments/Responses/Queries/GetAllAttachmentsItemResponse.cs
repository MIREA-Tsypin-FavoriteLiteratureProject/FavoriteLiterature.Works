namespace FavoriteLiterature.Works.Domain.Attachments.Responses.Queries;

public class GetAllAttachmentsItemResponse
{
    public Guid Id { get; set; }

    public Guid WorkId { get; set; }

    public Guid FileId { get; set; }

    public string AttachmentTypeId { get; set; } = null!;
}