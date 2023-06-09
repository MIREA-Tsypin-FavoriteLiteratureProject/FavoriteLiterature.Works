﻿namespace FavoriteLiterature.Works.Domain.Genres.Responses.Queries;

public class GetGenreResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}