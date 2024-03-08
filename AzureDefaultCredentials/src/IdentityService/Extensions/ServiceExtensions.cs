using Azure.Core;
using Azure.Identity;
using IdentityService.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityService.Extensions;

public static class ServiceExtensions
{
    public static void AddIdentityService(this IServiceCollection services, IHostEnvironment hostEnvironment)
    {
        var defaultAzureCredential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
        {
            ExcludeAzureCliCredential = false,
            ExcludeAzureDeveloperCliCredential = false,
            ExcludeAzurePowerShellCredential = false,
            ExcludeEnvironmentCredential = false,
            ExcludeInteractiveBrowserCredential = false,
            ExcludeManagedIdentityCredential = true,
            ExcludeSharedTokenCacheCredential = false,
            ExcludeVisualStudioCodeCredential = hostEnvironment.IsDevelopment(),
            ExcludeVisualStudioCredential = hostEnvironment.IsDevelopment(),
            ExcludeWorkloadIdentityCredential = false,
        });
        
        services.AddSingleton<TokenCredential>(defaultAzureCredential);
        services.AddScoped<ITokenManager, TokenManager>();
    }
}