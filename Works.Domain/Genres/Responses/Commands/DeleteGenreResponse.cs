using Newtonsoft.Json;

namespace FavoriteLiterature.Works.Domain.Genres.Responses.Commands;

public class DeleteGenreResponse
{
    [JsonProperty("name")]
    public string Name { get; }

    public DeleteGenreResponse(string name)
        => Name = name;
}