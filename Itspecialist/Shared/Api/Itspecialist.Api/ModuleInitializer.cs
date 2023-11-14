using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Itspecialist.Api
{
    public static partial class ModuleInitializer
    {
        public static void AddApi(this IServiceCollection services)
        {
            services.SetupAuthentication();

            services.AddSingleton<IApiBuilder, ApiBuilder>();
            services.AddSingleton<IBaseRepositoryProvider, BaseRepositoryProvider>();
        }

        private static void SetupAuthentication(this IServiceCollection services)
        {
            services.AddSingleton<ITokenProvider, TokenProvider>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
        }
    }
}
