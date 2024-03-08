using IdentityService.Abstractions;
using IdentityService.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;

namespace IdentityService.Tests;

[TestClass]
public class TokenManagerTests
{
    private const string AZURE_SCOPE = "api://endpoint";

    [TestMethod]
    public async Task GivenVsUser_WhenRequestingToken_TokenReturned()
    {
        var hostingEnvironment = new HostingEnvironment
        {
            EnvironmentName = "Development"
        };

        var services = new ServiceCollection();
        services.AddIdentityService(hostingEnvironment);

        var provider = services.BuildServiceProvider();

        var tokenProvider = provider.GetService<ITokenManager>();

        Assert.IsNotNull(tokenProvider);

        var token = await tokenProvider.GetBearerToken(AZURE_SCOPE);

        Assert.IsNotNull(token);
    }
}