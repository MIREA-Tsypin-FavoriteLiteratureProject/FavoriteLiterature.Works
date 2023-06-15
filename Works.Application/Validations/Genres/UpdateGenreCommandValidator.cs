using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;
using FluentValidation;

namespace FavoriteLiterature.Works.Application.Validations.Genres;

public sealed class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage(x => $"The {nameof(x.Name)} must not exceed 50 characters.");
    }
}