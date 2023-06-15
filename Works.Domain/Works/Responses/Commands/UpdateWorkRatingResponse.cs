namespace FavoriteLiterature.Works.Domain.Works.Responses.Commands;

public class UpdateWorkRatingResponse
{
    public Guid Id { get; }

    public UpdateWorkRatingResponse(Guid id) 
        => Id = id;
}