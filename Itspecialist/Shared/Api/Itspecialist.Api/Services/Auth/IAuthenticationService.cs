using Foundation.Api.Models;

namespace Itspecialist.Api.Services.Auth
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAndCacheTokenAsync(AuthPayload auth);
        Task<bool> RefreshAndCacheTokenAsync();
        Task<bool> RegisterAsync(string email, string password);
    }
}
