namespace IdentityService.Abstractions;

public interface ITokenManager
{
    Task<string> GetBearerToken(string scope);
}