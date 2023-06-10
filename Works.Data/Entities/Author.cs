using FavoriteLiterature.Works.Data.Entities.Abstract;

namespace FavoriteLiterature.Works.Data.Entities;

/// <summary>
/// Автор
/// </summary>
public sealed class Author : BaseEntity
{
    /// <summary>
    /// Псевдоним
    /// </summary>
    public string Alias { get; set; } = null!;

    /// <summary>
    /// Публичная почта для читателей
    /// </summary>
    public string PublicEmail { get; set; } = null!;
    
    /// <summary>
    /// Краткое описание "О себе"
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Уникальный идентификатор пользователя,
    /// имеющего роль - Автор
    /// </summary>
    public Guid UserId { get; set; }
    
    public ICollection<Work> Works { get; } = new List<Work>();
}