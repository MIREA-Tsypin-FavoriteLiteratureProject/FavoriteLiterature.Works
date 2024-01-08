using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Works.Requests.Commands;
using FavoriteLiterature.Works.Domain.Works.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Works.Commands;

public sealed class DeleteWorkCommandHandler : IRequestHandler<DeleteWorkCommand, DeleteWorkResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWorkCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<DeleteWorkResponse> Handle(DeleteWorkCommand command, CancellationToken cancellationToken)
    {
        var workData = await _unitOfWork.WorksRepository.GetAsync(x =>
                x.Id == command.Id,
            cancellationToken);
        if (workData == null)
        {
            throw new ArgumentException($"{command.Id} is not found.", nameof(command.Id));
        }

        await _unitOfWork.BeginTransactionAsync(new List<Action>
        {
            () => _unitOfWork.WorksRepository.Remove(workData)
        });

        return new DeleteWorkResponse(command.Id);
    }
}