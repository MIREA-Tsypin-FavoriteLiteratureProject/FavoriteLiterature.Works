namespace FavoriteLiterature.Works.Data.Entities;

/// <summary>
/// Жанр произведения
/// </summary>
/// <param name="Name">Наименование жанра</param>
/// <param name="Description">Описание жанра</param>
public sealed record Genre(string Name, string? Description);