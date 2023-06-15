using FavoriteLiterature.Works.Application.Handlers.RabbitMq;
using FavoriteLiterature.Works.Domain.RabbitMq;

namespace FavoriteLiterature.Works.Extensions.Builder.Common;

public static class RabbitMqExtensions
{
    public static void AddRabbitMqSubscriber(this WebApplicationBuilder builder)
    {
        builder.Services.AddOptions<RabbitMqOptions>().BindConfiguration("RabbitMq");
        builder.Services.AddHostedService<RabbitMqService>();
    }
}