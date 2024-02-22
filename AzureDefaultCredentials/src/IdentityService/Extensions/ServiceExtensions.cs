using Azure.Core;
using Azure.Identity;
using IdentityService.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Extensions;

public static class ServiceExtensions
{
    public static void AddIdentityService(this IServiceCollection services)
    {
        services.AddSingleton<TokenCredential>(new DefaultAzureCredential());
        services.AddScoped<ITokenManager, TokenManager>();
    }
}