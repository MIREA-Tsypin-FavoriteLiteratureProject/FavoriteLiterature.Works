using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Works.Data.Common;
using Works.Data.Entities;

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