namespace FavoriteLiterature.Works.Domain.Authors.Responses.Commands;

public class CreateAuthorResponse
{
    public Guid Id { get; }

    public CreateAuthorResponse(Guid id)
        => Id = id;
}