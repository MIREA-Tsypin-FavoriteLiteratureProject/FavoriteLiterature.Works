using FavoriteLiterature.Works.Data.Entities.Abstract;

namespace FavoriteLiterature.Works.Data.Entities;

/// <summary>
/// Вложение
/// </summary>
public sealed class Attachment : BaseEntity
{
    /// <summary>
    /// Уникальный идентификатор работы писателя
    /// </summary>
    public Guid WorkId { get; set; }
    public Work Work { get; set; }
    
    /// <summary>
    /// Уникальный идентификатор файла,
    /// его номер на файл-сервере
    /// </summary>
    public Guid FileId { get; set; }

    /// <summary>
    /// Тип вложения
    /// </summary>
    public string AttachmentTypeId { get; set; } = null!;
}