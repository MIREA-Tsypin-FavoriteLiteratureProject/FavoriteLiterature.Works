using FavoriteLiterature.Works.Application.Options;

namespace FavoriteLiterature.Works.Extensions.Builder.Common;

public static class AttachmentStorageExtensions
{
    public static void AddAttachmentStorage(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<AttachmentStorageOptions>(builder.Configuration.GetSection("AttachmentStorage"));
    }
}