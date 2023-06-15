using FavoriteLiterature.Works.Domain.Works.Requests.Commands;
using FluentValidation;

namespace FavoriteLiterature.Works.Application.Validations.Works;

public sealed class UpdateWorkRatingCommandValidator : AbstractValidator<UpdateWorkRatingCommand>
{
    public UpdateWorkRatingCommandValidator()
    {
        RuleFor(x => x.Rating)
            .NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(5);
    }
}