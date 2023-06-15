namespace FavoriteLiterature.Works.Domain.Authors.Responses.Commands;

public class UpdateAuthorResponse
{
    public Guid Id { get; }

    public UpdateAuthorResponse(Guid id)
        => Id = id;
}