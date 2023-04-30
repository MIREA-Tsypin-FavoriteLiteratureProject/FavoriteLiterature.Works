using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Works.Data.Common;
using Works.Data.Configurations.Abstract;
using Works.Data.Entities;

namespace Works.Data.Configurations;

public sealed class AttachmentConfiguration : BaseEntityConfiguration<Attachment>
{
    protected override void ConfigureProperties(EntityTypeBuilder<Attachment> builder)
    {
        builder.ToTable(WorksApiTables.Attachments);
        builder.HasKey(x => x.Id).HasName($"{WorksApiTables.Attachments}_pkey");

        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
        builder.Property(x => x.WorkId).HasColumnName($"{WorksApiTables.Works}_id").IsRequired();
        builder.Property(x => x.FileId).HasColumnName("file_id").IsRequired();
        builder.Property(x => x.TypeId).HasColumnName($"{WorksApiTables.AttachmentTypes}_id").IsRequired();
    }
}