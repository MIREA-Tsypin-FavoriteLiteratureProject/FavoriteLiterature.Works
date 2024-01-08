namespace FavoriteLiterature.Works.Domain.Authors.Responses.Commands;

public class DeleteAuthorResponse
{
    public Guid Id { get; }

    public DeleteAuthorResponse(Guid id)
        => Id = id;
}