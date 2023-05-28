using FavoriteLiterature.Works.Domain.RabbitMq;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Works.Requests.Commands;

public class CreateWorkCommand : DraftModel, IRequest
{
}