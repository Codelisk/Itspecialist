using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation.Api.Models;
using Itspecialist.Api.Models.Auth;
using Itspecialist.Api.Repositories;
using Itspecialist.Api.Services.Auth;

namespace Itspecialist.Services
{
    internal class AuthenticationService : Api.Services.Auth.IAuthenticationService
    {
        private const string AuthProvider = "AuthProvider";
        private const string AccessTokenKey = "AccessTokenKey";
        private readonly ITokenProvider _tokenProvider;
        private readonly IAuthRepository _authRepository;

        public AuthenticationService(IAuthRepository authRepository, ITokenProvider tokenProvider)
        {
            _authRepository = authRepository;
            _tokenProvider = tokenProvider;
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            var authResult = await _authRepository.RegisterAsync(new AuthPayload() { email = email, password = password });
            _tokenProvider.UpdateCurrentToken(authResult.accessToken, authResult.refreshToken);
            return true;
        }

        public async Task<bool> AuthenticateAndCacheTokenAsync(AuthPayload auth)
        {
            var authResult = await _authRepository.LoginAsync(auth);
            //await _tokenCache.SaveAsync(AuthProvider, new Dictionary<string, string> { { AccessTokenKey, authResult.accessToken } }, default);
            _tokenProvider.UpdateCurrentToken(authResult.accessToken, authResult.refreshToken);
            return true;
        }

        public async Task<bool> RefreshAndCacheTokenAsync()
        {
            var refreshToken = _tokenProvider.GetCurrentRefreshToken();
            var authResult = await _authRepository.RefreshAsync(refreshToken);
            //await _tokenCache.SaveAsync(AuthProvider, new Dictionary<string, string> { { AccessTokenKey, authResult.accessToken } }, default);
            _tokenProvider.UpdateCurrentToken(authResult.accessToken, authResult.refreshToken);
            return true;
        }
    }
}
