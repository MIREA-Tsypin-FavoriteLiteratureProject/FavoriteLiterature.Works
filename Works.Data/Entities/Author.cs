using FavoriteLiterature.Works.Data.Entities.Abstract;

namespace FavoriteLiterature.Works.Data.Entities;

/// <summary>
/// Сущность - Автор
/// </summary>
public sealed class Author : BaseEntity
{
    /// <summary>
    /// Псевдоним
    /// </summary>
    public string NickName { get; set; } = null!;

    /// <summary>
    /// Полное ФИО
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Публичная почта для читателей
    /// </summary>
    public string PublicEmail { get; set; } = null!;

    /// <summary>
    /// Краткое описание "О себе"
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Навигационное свойство для EF
    /// </summary>
    public ICollection<Work> Works { get; } = new List<Work>();
}