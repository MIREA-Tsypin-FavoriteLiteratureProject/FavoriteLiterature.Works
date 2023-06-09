﻿using FavoriteLiterature.Works.Data.Common;
using FavoriteLiterature.Works.Data.Configurations.Abstract;
using FavoriteLiterature.Works.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoriteLiterature.Works.Data.Configurations;

public sealed class AuthorConfiguration : BaseEntityConfiguration<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable(WorksApiTables.Authors);
        builder.HasKey(x => x.Id).HasName($"{WorksApiTables.Authors}_pkey");
        builder.HasIndex(x => x.UserId).IsUnique();

        builder.Property(x => x.Id).HasColumnName("id").IsRequired();
        builder.Property(x => x.Alias).HasColumnName("alias").HasMaxLength(100).IsRequired();
        builder.Property(x => x.PublicEmail).HasColumnName("public_email").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description");
        builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
    }
}