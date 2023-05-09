using Newtonsoft.Json;

namespace FavoriteLiterature.Works.Domain.Genres.Responses.Queries;

public class GetAllGenresItemResponse
{
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("description")]
    public string? Description { get; set; }
}