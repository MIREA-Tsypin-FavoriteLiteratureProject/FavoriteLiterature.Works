using FavoriteLiterature.Works.Data;
using FavoriteLiterature.Works.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Works.Extensions.Builder;

public static class DatabaseExtensions
{
    public static void AddPostgresDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Connection string is missing.");
        }

        builder.Services.AddDbContext<FavoriteLiteratureWorksDbContext>(options => options.UseNpgsql(connectionString));
    }
    
    public static void SeedDatabase(this WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();
        var mainContext = serviceScope.ServiceProvider.GetRequiredService<FavoriteLiteratureWorksDbContext>();

        DatabaseInitializer.Initialize(mainContext);
    }
}