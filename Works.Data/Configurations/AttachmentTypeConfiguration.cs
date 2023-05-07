using FavoriteLiterature.Works.Data.Common;
using FavoriteLiterature.Works.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Works.Data.Configurations;

public sealed class AttachmentTypeConfiguration : IEntityTypeConfiguration<AttachmentType>
{
    public void Configure(EntityTypeBuilder<AttachmentType> builder)
    {
        ConfigureProperties(builder);
    }

    private static void ConfigureProperties(EntityTypeBuilder<AttachmentType> builder)
    {
        builder.ToTable(WorksApiTables.AttachmentTypes);
        builder.HasKey(x => x.Name).HasName($"{WorksApiTables.AttachmentTypes}_pkey");

        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(30).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description");
    }
}