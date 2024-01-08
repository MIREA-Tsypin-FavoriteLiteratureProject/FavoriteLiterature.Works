namespace FavoriteLiterature.Works.Domain.Works.Responses.Commands;

public class CreateWorkResponse
{
    public Guid Id { get; }

    public CreateWorkResponse(Guid id)
        => Id = id;
}