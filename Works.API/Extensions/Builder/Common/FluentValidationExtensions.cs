using System.Globalization;
using FavoriteLiterature.Works.Application.Validations.Authors;
using FavoriteLiterature.Works.Application.Validations.Genres;
using FavoriteLiterature.Works.Application.Validations.Works;
using FavoriteLiterature.Works.Domain.Authors.Requests.Commands;
using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;
using FavoriteLiterature.Works.Domain.Works.Requests.Commands;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace FavoriteLiterature.Works.Extensions.Builder.Common;

public static class FluentValidationExtensions
{
    public static void AddFluentValidation(this WebApplicationBuilder builder)
    {
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");

        builder.Services.AddScoped<IValidator<CreateAuthorCommand>, CreateAuthorCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateAuthorCommand>, UpdateAuthorCommandValidator>();

        builder.Services.AddScoped<IValidator<CreateGenreCommand>, CreateGenreCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateGenreCommand>, UpdateGenreCommandValidator>();

        builder.Services.AddScoped<IValidator<UpdateWorkRatingCommand>, UpdateWorkRatingCommandValidator>();

        builder.Services.AddFluentValidationAutoValidation();
    }
}