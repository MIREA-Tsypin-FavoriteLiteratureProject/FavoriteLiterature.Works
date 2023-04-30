﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Works.Data.Common;
using Works.Data.Configurations.Abstract;
using Works.Data.Entities;

namespace Works.Data.Configurations;

public sealed class AuthorConfiguration : BaseEntityConfiguration<Author>
{
    protected override void ConfigureProperties(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable(WorksApiTables.Authors);
        builder.HasKey(x => x.Id).HasName($"{WorksApiTables.Authors}_pkey");

        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
        builder.Property(x => x.PublicEmail).HasColumnName("public_email").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description");
        builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
    }
}