using FavoriteLiterature.Works.Data.Common;
using FavoriteLiterature.Works.Data.Configurations.Abstract;
using FavoriteLiterature.Works.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoriteLiterature.Works.Data.Configurations;

public sealed class AttachmentConfiguration : BaseEntityConfiguration<Attachment>
{
    public override void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.ToTable(WorksApiTables.Attachments);
        builder.HasKey(x => x.Id).HasName($"{WorksApiTables.Attachments}_pkey");

        builder.Property(x => x.Id).HasColumnName("id").IsRequired();
        builder.Property(x => x.WorkId).HasColumnName($"{WorksApiTables.Works}_id").IsRequired();
        builder.Property(x => x.FileId).HasColumnName("file_id").IsRequired();
        builder.Property(x => x.AttachmentTypeId).HasColumnName("attachment_types_id").IsRequired();
    }
}