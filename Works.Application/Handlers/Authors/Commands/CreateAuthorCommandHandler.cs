using AutoMapper;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Authors.Requests.Commands;
using FavoriteLiterature.Works.Domain.Authors.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Authors.Commands;

public sealed class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, CreateAuthorResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateAuthorResponse> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
    {
        var isAuthorExists = await _unitOfWork.AuthorsRepository.ExistsAsync(x =>
                x.PublicEmail == command.PublicEmail,
            cancellationToken);
        if (isAuthorExists)
        {
            throw new ArgumentException("Author with this email is already exists", nameof(command.PublicEmail));
        }

        var authorData = _mapper.Map<Author>(command);

        await _unitOfWork.BeginTransactionAsync(new[]
        {
            () => _unitOfWork.AuthorsRepository.Add(authorData)
        });

        return new CreateAuthorResponse(authorData.Id);
    }
}