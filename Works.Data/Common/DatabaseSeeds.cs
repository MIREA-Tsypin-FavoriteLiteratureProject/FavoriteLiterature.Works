using FavoriteLiterature.Works.Data.Entities;

namespace FavoriteLiterature.Works.Data.Common;

public static class DatabaseSeeds
{
    public static readonly IEnumerable<AttachmentType> AttachmentTypes = new[]
    {
        new AttachmentType("Cover", "En: Link to the cover (main picture) of the writer's work. Рус: Ссылка на обложку (основную картинку) работы писателя."),
        new("Document", "En: A link to a document related to the writer's work. Рус: Ссылка на документ связанный с работой писателя."),
        new("Work", "En: Link to the writer's work. Рус: Ссылка на работу писателя."),
        new("Image", "En: A link to a picture related to the writer's work. Рус: Ссылка на картинку связанная с работой писателя.")
    };
}