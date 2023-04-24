﻿using Works.Data.Entities.Abstract;

namespace Works.Data.Entities;

/// <summary>
/// Автор
/// </summary>
public sealed class Author : BaseEntity
{
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