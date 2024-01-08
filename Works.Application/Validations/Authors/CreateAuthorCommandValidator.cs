using FavoriteLiterature.Works.Domain.Authors.Requests.Commands;
using FluentValidation;

namespace FavoriteLiterature.Works.Application.Validations.Authors;

public sealed class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(x => x.NickName)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage(x => $"The {nameof(x.NickName)} must not exceed 100 characters.");

        RuleFor(x => x.PublicEmail)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100)
            .WithMessage(x => $"The {nameof(x.PublicEmail)} must not exceed 100 characters.");
    }
}