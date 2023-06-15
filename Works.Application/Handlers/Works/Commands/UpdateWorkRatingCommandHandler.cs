using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Works.Requests.Commands;
using FavoriteLiterature.Works.Domain.Works.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Works.Commands;

public sealed class UpdateWorkRatingCommandHandler : IRequestHandler<UpdateWorkRatingCommand, UpdateWorkRatingResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWorkRatingCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateWorkRatingResponse> Handle(UpdateWorkRatingCommand command, CancellationToken cancellationToken)
    {
        var workData = await _unitOfWork.WorksRepository.GetAsync(x =>
                x.Id == command.Id,
            cancellationToken);
        if (workData == null)
        {
            throw new ArgumentException("Work is not found!", nameof(command.Id));
        }

        var sumOfRatings = workData.Rating * workData.RatingCounter + command.Rating;
        
        workData.RatingCounter++;
        workData.Rating = Math.Round(sumOfRatings / workData.RatingCounter, 4);

        await _unitOfWork.BeginTransactionAsync(new[]
        {
            () => _unitOfWork.WorksRepository.Update(workData)
        });

        return new UpdateWorkRatingResponse(workData.Id);
    }
}
