using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Works.Data.Common;

public static class DatabaseInitializer
{
    public static void Initialize(FavoriteLiteratureWorksDbContext context)
    {
        if (!context.Database.CanConnect())
        {
            context.Database.Migrate();
        }
    }
}