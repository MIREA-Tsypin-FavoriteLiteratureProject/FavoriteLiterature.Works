namespace FavoriteLiterature.Works.Data.Entities;

/// <summary>
/// Тип вложения
/// </summary>
/// <param name="Name">Наименование типа вложения</param>
/// <param name="Description">Описание типа вложения</param>
public sealed record AttachmentType(string Name, string? Description);