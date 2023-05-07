using FavoriteLiterature.Works.Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoriteLiterature.Works.Data.Configurations.Abstract;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
}