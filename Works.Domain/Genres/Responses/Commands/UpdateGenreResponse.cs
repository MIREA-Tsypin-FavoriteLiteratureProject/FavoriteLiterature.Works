using Newtonsoft.Json;

namespace FavoriteLiterature.Works.Domain.Genres.Responses.Commands;

public class UpdateGenreResponse
{
    [JsonProperty("name")]
    public string Name { get; }

    public UpdateGenreResponse(string name)
        => Name = name;
}