using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Authors.Requests.Commands;
using FavoriteLiterature.Works.Domain.Authors.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Authors.Commands;

public sealed class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, DeleteAuthorResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork) 
        => _unitOfWork = unitOfWork;

    public async Task<DeleteAuthorResponse> Handle(DeleteAuthorCommand command, CancellationToken cancellationToken)
    {
        var authorData = await _unitOfWork.AuthorsRepository.GetAsync(x =>
                x.Id == command.Id,
            cancellationToken);
        if (authorData == null)
        {
            throw new ArgumentException($"{command.Id} is not found.", nameof(command.Id));
        }

        await _unitOfWork.BeginTransactionAsync(new List<Action>
        {
            () => _unitOfWork.AuthorsRepository.Remove(authorData)
        });

        return new DeleteAuthorResponse(command.Id);
    }
}