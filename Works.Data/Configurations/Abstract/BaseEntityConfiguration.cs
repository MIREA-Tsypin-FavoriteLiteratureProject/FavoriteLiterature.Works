﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Works.Data.Entities.Abstract;

namespace Works.Data.Configurations.Abstract;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ConfigureProperties(builder);
    }
    
    protected abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);
}