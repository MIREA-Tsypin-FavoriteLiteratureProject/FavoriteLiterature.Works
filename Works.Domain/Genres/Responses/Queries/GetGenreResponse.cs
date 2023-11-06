﻿namespace FavoriteLiterature.Works.Domain.Genres.Responses.Queries;

public class GetGenreResponse
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }
}