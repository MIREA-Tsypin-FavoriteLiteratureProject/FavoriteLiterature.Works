using FavoriteLiterature.Works.Data.Entities.Abstract;

namespace FavoriteLiterature.Works.Data.Entities;

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
    /// Счётчик количества оценок
    /// </summary>
    public int RatingCounter { get; set; }

    /// <summary>
    /// Краткое описание произведения 
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Ссылка на авторов
    /// </summary>
    public ICollection<Author> Authors { get; } = new List<Author>();

    /// <summary>
    /// Ссылка на жанры
    /// </summary>
    public ICollection<Genre> Genres { get; } = new List<Genre>();

    /// <summary>
    /// Ссылка на вложения
    /// </summary>
    public ICollection<Attachment> Attachments { get; } = new List<Attachment>();
}