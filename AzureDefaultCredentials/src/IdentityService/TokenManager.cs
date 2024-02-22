using Azure.Core;
using IdentityService.Abstractions;

namespace IdentityService;

public class TokenManager : ITokenManager
{
    private readonly TokenCredential _tokenCredential;

    public TokenManager(TokenCredential tokenCredential)
    {
        _tokenCredential = tokenCredential;
    }

    public async Task<string> GetBearerToken(string scope, string tenant)
    {
        try
        {
            var tokenRequestContext = new TokenRequestContext(new[] { scope }, tenantId: tenant);
            var accessToken = await _tokenCredential.GetTokenAsync(tokenRequestContext, CancellationToken.None);

            return accessToken.Token;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}