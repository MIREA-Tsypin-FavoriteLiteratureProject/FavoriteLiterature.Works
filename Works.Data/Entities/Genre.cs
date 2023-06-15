using FavoriteLiterature.Works.Data.Entities.Abstract;

namespace FavoriteLiterature.Works.Data.Entities;

/// <summary>
/// Жанр произведения
/// </summary>
public sealed class Genre : BaseEntity
{
    /// <summary>
    /// Имя жанра
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Краткое описание
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Ссылка на работы
    /// </summary>
    public ICollection<Work> Works { get; } = new List<Work>();
}