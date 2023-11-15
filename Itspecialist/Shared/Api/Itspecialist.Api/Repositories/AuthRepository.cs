using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation.Api.Models;
using Itspecialist.Api.Models.Auth;

namespace Itspecialist.Api.Repositories
{
    internal class AuthRepository : BaseRepository<IAuthApi>, IAuthRepository
    {
        public AuthRepository(IBaseRepositoryProvider baseRepositoryProvider) : base(baseRepositoryProvider)
        {
        }
        public Task<AuthResult> LoginAsync(AuthPayload request) => TryRequest(() => _repositoryApi.Login(request));
        public Task<AuthResult> RefreshAsync(string refreshToken) => TryRequest(() => _repositoryApi.Refresh(refreshToken));
    }
}
