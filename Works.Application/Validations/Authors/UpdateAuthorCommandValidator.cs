using FavoriteLiterature.Works.Domain.Authors.Requests.Commands;
using FluentValidation;

namespace FavoriteLiterature.Works.Application.Validations.Authors;

public sealed class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(x => x.NickName)
            .MaximumLength(100)
            .WithMessage(x => $"The {nameof(x.NickName)} must not exceed 100 characters.");

        RuleFor(x => x.PublicEmail)
            .EmailAddress()
            .When(x => !string.IsNullOrEmpty(x.PublicEmail))
            .MaximumLength(100)
            .WithMessage(x => $"The {nameof(x.PublicEmail)} must not exceed 100 characters.");
    }
}