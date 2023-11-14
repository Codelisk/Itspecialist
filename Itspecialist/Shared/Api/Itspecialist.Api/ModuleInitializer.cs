using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Api.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Itspecialist.Api
{
    public static partial class ModuleInitializer
    {
        public static void AddApi(this IServiceCollection services, IAuthenticationService authenticationService)
        {
            services.SetupAuthentication(authenticationService);

            services.AddSingleton<IApiBuilder, ApiBuilder>();
            services.AddSingleton<IBaseRepositoryProvider, BaseRepositoryProvider>();
        }

        private static void SetupAuthentication(this IServiceCollection services, IAuthenticationService authenticationService)
        {
            services.AddSingleton<ITokenProvider, TokenProvider>();
            services.AddSingleton<IAuthRepository, AuthRepository>();
            services.AddSingleton<IAuthenticationService>(x => authenticationService);
        }
    }
}
