using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation.Api.Models;

namespace Itspecialist.Api.Services.Auth
{
    internal class AuthenticationService : IAuthenticationService
    {
        public Task<bool> AuthenticateAndCacheTokenAsync(AuthPayload auth)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RefreshAndCacheTokenAsync()
        {
            throw new NotImplementedException();
        }
    }
}
