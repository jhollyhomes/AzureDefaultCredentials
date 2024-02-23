using IdentityService.Abstractions;
using IdentityService.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Tests;

[TestClass]
public class TokenManagerTests
{
    private const string AZURE_SCOPE = "api://ruc.ir.vehicledatamock.test1697790249825";

    [TestMethod]
    public async Task GivenVsUser_WhenRequestingToken_TokenReturned()
    {
        var services = new ServiceCollection();
        services.AddIdentityService();

        var provider = services.BuildServiceProvider();

        var tokenProvider = provider.GetService<ITokenManager>();

        Assert.IsNotNull(tokenProvider);

        var token = await tokenProvider.GetBearerToken(AZURE_SCOPE);

        Assert.IsNotNull(token);
    }
}