using Newtonsoft.Json;

namespace FavoriteLiterature.Works.Domain.Genres.Responses.Commands;

public class CreateGenreResponse
{
    [JsonProperty("name")]
    public string Name { get; }

    public CreateGenreResponse(string name)
        => Name = name;
}