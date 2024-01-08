namespace FavoriteLiterature.Works.Domain.Works.Responses.Commands;

public class DeleteWorkResponse
{
    public Guid Id { get; }

    public DeleteWorkResponse(Guid id)
        => Id = id;
}