namespace FavoriteLiterature.Works.Data.Entities.Abstract;

/// <summary>
/// Базовая сущность,
/// имеющая общие поля у большинства таблиц
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();
}