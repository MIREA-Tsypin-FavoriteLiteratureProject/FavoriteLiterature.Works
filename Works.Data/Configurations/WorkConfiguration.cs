using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Works.Data.Common;
using Works.Data.Configurations.Abstract;
using Works.Data.Entities;

namespace Works.Data.Configurations;

public sealed class WorkConfiguration : BaseEntityConfiguration<Work>
{
    protected override void ConfigureProperties(EntityTypeBuilder<Work> builder)
    {
        builder.ToTable(WorksApiTables.Works);
        builder.HasKey(x => x.Id).HasName($"{WorksApiTables.Works}_pkey");

        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Rating).HasColumnName("rating");
        builder.Property(x => x.Description).HasColumnName("description");
    }
}