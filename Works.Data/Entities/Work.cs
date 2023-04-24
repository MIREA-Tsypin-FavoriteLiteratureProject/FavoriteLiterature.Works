using Works.Data.Entities.Abstract;

namespace Works.Data.Entities;

/// <summary>
/// Произведение
/// </summary>
public sealed class Work : BaseEntity
{
    /// <summary>
    /// Наименование произведения
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Рейтинг произведения
    /// </summary>
    public decimal Rating { get; set; }

    /// <summary>
    /// Краткое описание произведения 
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Ссылка на авторов произведения
    /// </summary>
    public ICollection<Author> Authors { get; } = new List<Author>();

    /// <summary>
    /// Жанры произведения
    /// </summary>
    public ICollection<Genre> Genres { get; } = new List<Genre>();
}