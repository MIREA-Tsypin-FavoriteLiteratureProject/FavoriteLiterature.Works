using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Authors.Requests.Commands;
using FavoriteLiterature.Works.Domain.Authors.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Authors.Commands;

public sealed class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, UpdateAuthorResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<UpdateAuthorResponse> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
    {
        var authorData = await _unitOfWork.AuthorsRepository.GetAsync(x =>
                x.Id == command.Id,
            cancellationToken);
        if (authorData == null)
        {
            throw new ArgumentException("Author is not found", nameof(command.Id));
        }

        if (!string.IsNullOrWhiteSpace(command.Alias) && command.Alias != authorData.NickName)
        {
            authorData.NickName = command.Alias;
        }

        if (!string.IsNullOrWhiteSpace(command.PublicEmail) && command.PublicEmail != authorData.PublicEmail)
        {
            authorData.PublicEmail = command.PublicEmail;
        }

        if (!string.IsNullOrWhiteSpace(command.Description))
        {
            authorData.Description = command.Description;
        }

        await _unitOfWork.BeginTransactionAsync(new[]
        {
            () => _unitOfWork.AuthorsRepository.Update(authorData)
        });

        return new UpdateAuthorResponse(authorData.Id);
    }
}