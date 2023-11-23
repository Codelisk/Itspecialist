using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation.Api.Models;
using Itspecialist.Api.Models.Auth;
using Itspecialist.Api.Repositories;
using Itspecialist.Api.Services.Auth;
using Uno.Extensions.Authentication;

namespace Itspecialist.Services
{
    internal class AuthenticationService : Api.Services.Auth.IAuthenticationService
    {
        private const string AuthProvider = "AuthProvider";
        private const string AccessTokenKey = "AccessTokenKey";
        private readonly ITokenProvider _tokenProvider;
        private readonly ITokenCache _tokenCache;
        private readonly IKeyValueStorage _keyValueStorage;
        private readonly IDispatcher _dispatcher;
        private readonly Uno.Extensions.Authentication.IAuthenticationService _authenticationService;
        private readonly IAuthRepository _authRepository;

        public AuthenticationService(IDispatcher dispatcher, Uno.Extensions.Authentication.IAuthenticationService authenticationService, IAuthRepository authRepository, IKeyValueStorage keyValueStorage, ITokenProvider tokenProvider, ITokenCache tokenCache)
        {
            _dispatcher = dispatcher;
            _authenticationService = authenticationService;
            _authRepository = authRepository;
            _keyValueStorage = keyValueStorage;
            _tokenProvider = tokenProvider;
            _tokenCache = tokenCache;
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            var authResult = await _authRepository.RegisterAndLoginAsync(new AuthPayload() { email = email, password = password });
            await _authenticationService.LoginAsync(_dispatcher, new Dictionary<string, string>
            {
                { "email", email},
                { "password", password}
            });
            return true;
        }

        public async Task<bool> AuthenticateAndCacheTokenAsync(AuthPayload auth)
        {
            return await _authenticationService.LoginAsync(_dispatcher, new Dictionary<string,string>() 
            { 
                { "email", auth.email},
                { "password", auth.password}
            });
        }

        public async Task<bool> RefreshAndCacheTokenAsync()
        {
            return await _authenticationService.RefreshAsync(CancellationToken.None);
        }
    }
}
