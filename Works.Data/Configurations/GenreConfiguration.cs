using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Works.Data.Common;
using Works.Data.Entities;

namespace Works.Data.Configurations;

public sealed class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        ConfigureProperties(builder);
    }

    private static void ConfigureProperties(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable(WorksApiTables.Genres);
        builder.HasKey(x => x.Name).HasName($"{WorksApiTables.Genres}_pkey");

        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description");
    }
}