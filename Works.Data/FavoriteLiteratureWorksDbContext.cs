using Microsoft.EntityFrameworkCore;
using Works.Data.Configurations;
using Works.Data.Entities;

namespace Works.Data;

public sealed class FavoriteLiteratureWorksDbContext : DbContext
{
    #region DbSets

    public DbSet<Attachment> Attachments { get; set; } = null!;
    
    public DbSet<AttachmentType> AttachmentTypes { get; set; } = null!;
    
    public DbSet<Author> Authors { get; set; } = null!;
    
    public DbSet<Genre> Genres { get; set; } = null!;
    
    public DbSet<Work> Works { get; set; } = null!;

    #endregion
    
    public FavoriteLiteratureWorksDbContext(DbContextOptions<FavoriteLiteratureWorksDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new AttachmentConfiguration().Configure(modelBuilder.Entity<Attachment>());
        new AttachmentTypeConfiguration().Configure(modelBuilder.Entity<AttachmentType>());
        new AuthorConfiguration().Configure(modelBuilder.Entity<Author>());
        new GenreConfiguration().Configure(modelBuilder.Entity<Genre>());
        new WorkConfiguration().Configure(modelBuilder.Entity<Work>());
    }
}