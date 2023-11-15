using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation.Api.Models;
using Itspecialist.Api.Models.Auth;

namespace Itspecialist.Api.Apis
{
    public partial interface IAuthApi : IBaseApi
    {
        [Post("/login")]
        Task<AuthResult> Login([Body] AuthPayload request);
        [Post("/register")]
        Task<AuthResult> Register([Body] AuthPayload request);
        [Post("/refresh")]
        Task<AuthResult> Refresh([Body] string refreshToken);
    }
}
