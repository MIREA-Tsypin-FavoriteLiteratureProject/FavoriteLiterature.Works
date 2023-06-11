using FavoriteLiterature.Works.Data.Common;
using FavoriteLiterature.Works.Data.Configurations.Abstract;
using FavoriteLiterature.Works.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoriteLiterature.Works.Data.Configurations;

public sealed class WorkConfiguration : BaseEntityConfiguration<Work>
{
    public override void Configure(EntityTypeBuilder<Work> builder)
    {
        builder.ToTable(WorksApiTables.Works);
        builder.HasKey(x => x.Id).HasName($"{WorksApiTables.Works}_pkey");

        builder.Property(x => x.Id).HasColumnName("id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Rating).HasColumnName("rating");
        builder.Property(x => x.RatingCounter).HasColumnName("rating_counter");
        builder.Property(x => x.Description).HasColumnName("description");
    }
}