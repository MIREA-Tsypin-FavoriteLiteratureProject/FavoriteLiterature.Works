using Newtonsoft.Json;

namespace FavoriteLiterature.Works.Domain.Genres.Responses.Queries;

public class GetGenreResponse
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }
}