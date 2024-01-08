namespace FavoriteLiterature.Works.Domain.Works.Responses.Commands;

public class UpdateWorkResponse
{
    public Guid Id { get; }

    public UpdateWorkResponse(Guid id)
        => Id = id;
}