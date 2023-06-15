﻿// <auto-generated />
using System;
using FavoriteLiterature.Works.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FavoriteLiterature.Works.Data.Migrations
{
    [DbContext(typeof(FavoriteLiteratureWorksDbContext))]
    [Migration("20230611102545_AddRatingCounterPropertyForWorkTable")]
    partial class AddRatingCounterPropertyForWorkTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuthorWork", b =>
                {
                    b.Property<Guid>("AuthorsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorksId")
                        .HasColumnType("uuid");

                    b.HasKey("AuthorsId", "WorksId");

                    b.HasIndex("WorksId");

                    b.ToTable("AuthorWork");
                });

            modelBuilder.Entity("FavoriteLiterature.Works.Data.Entities.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AttachmentTypeId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("attachment_types_id");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid")
                        .HasColumnName("file_id");

                    b.Property<Guid>("WorkId")
                        .HasColumnType("uuid")
                        .HasColumnName("works_id");

                    b.HasKey("Id")
                        .HasName("attachments_pkey");

                    b.HasIndex("WorkId");

                    b.ToTable("attachments", (string)null);
                });

            modelBuilder.Entity("FavoriteLiterature.Works.Data.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("alias");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("PublicEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("public_email");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("authors_pkey");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("authors", (string)null);
                });

            modelBuilder.Entity("FavoriteLiterature.Works.Data.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("genres_pkey");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("genres", (string)null);
                });

            modelBuilder.Entity("FavoriteLiterature.Works.Data.Entities.Work", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric")
                        .HasColumnName("rating");

                    b.Property<int>("RatingCounter")
                        .HasColumnType("integer")
                        .HasColumnName("rating_counter");

                    b.HasKey("Id")
                        .HasName("works_pkey");

                    b.ToTable("works", (string)null);
                });

            modelBuilder.Entity("GenreWork", b =>
                {
                    b.Property<Guid>("GenresId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorksId")
                        .HasColumnType("uuid");

                    b.HasKey("GenresId", "WorksId");

                    b.HasIndex("WorksId");

                    b.ToTable("GenreWork");
                });

            modelBuilder.Entity("AuthorWork", b =>
                {
                    b.HasOne("FavoriteLiterature.Works.Data.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FavoriteLiterature.Works.Data.Entities.Work", null)
                        .WithMany()
                        .HasForeignKey("WorksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FavoriteLiterature.Works.Data.Entities.Attachment", b =>
                {
                    b.HasOne("FavoriteLiterature.Works.Data.Entities.Work", "Work")
                        .WithMany("Attachments")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Work");
                });

            modelBuilder.Entity("GenreWork", b =>
                {
                    b.HasOne("FavoriteLiterature.Works.Data.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FavoriteLiterature.Works.Data.Entities.Work", null)
                        .WithMany()
                        .HasForeignKey("WorksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FavoriteLiterature.Works.Data.Entities.Work", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
