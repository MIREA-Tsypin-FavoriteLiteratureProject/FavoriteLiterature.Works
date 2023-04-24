using Works.Data.Entities.Abstract;

namespace Works.Data.Entities;

/// <summary>
/// Вложение
/// </summary>
public sealed class Attachment : BaseEntity
{
    /// <summary>
    /// Уникальный идентификатор работы писателя
    /// </summary>
    public Guid WorkId { get; set; }
    public Work Work { get; set; } = null!;
    
    /// <summary>
    /// Уникальный идентификатор файла,
    /// его номер на файл-сервере
    /// </summary>
    public Guid FileId { get; set; }
    
    /// <summary>
    /// Тип вложения
    /// </summary>
    public Guid TypeId { get; set; }
    public Type Type { get; set; } = null!;
}