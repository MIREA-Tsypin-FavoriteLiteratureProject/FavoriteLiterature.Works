using FavoriteLiterature.Works.Application.Handlers.Common.Policies;
using FavoriteLiterature.Works.Application.Policies;
using Microsoft.AspNetCore.Authorization;

namespace FavoriteLiterature.Works.Extensions.Builder.Common;

public static class AuthorizationExtensions
{
    public static void AddRolePolicy(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthorizationHandler, MinimumRoleRequirementHandler>();

        builder.Services.AddAuthorization(options =>
        {
            // Настройка политик доступа для роли - Пользователь.
            options.AddPolicy(nameof(RolePolicy.User), policy =>
                policy.Requirements.Add(new MinimumRoleRequirement("user")));
            
            // Настройка политик доступа для роли - Автор.
            options.AddPolicy(nameof(RolePolicy.Author), policy =>
                policy.Requirements.Add(new MinimumRoleRequirement("author")));

            // Настройка политик доступа для роли - Критик.
            options.AddPolicy(nameof(RolePolicy.Critic), policy =>
                policy.Requirements.Add(new MinimumRoleRequirement("critic")));
        });
    }
}