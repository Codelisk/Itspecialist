using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Api.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Itspecialist.Api
{
    public class ModuleInitializerBase
    {
        public virtual void AddApis(IServiceCollection services) { }
    }
    public partial class ModuleInitializer : ModuleInitializerBase
    {
        public virtual void AddApi<TAuthService>(IServiceCollection services) where TAuthService : class, IAuthenticationService
        {
            AddApis(services);
            SetupAuthentication<TAuthService>(services);

            services.AddSingleton<IApiBuilder, ApiBuilder>();
            services.AddSingleton<IBaseRepositoryProvider, BaseRepositoryProvider>();

            services.AddAddRepositories();
        }

        private void SetupAuthentication<TAuthService>(IServiceCollection services) where TAuthService : class, IAuthenticationService
        {
            services.AddSingleton<ITokenProvider, TokenProvider>();
            services.AddSingleton<IAuthRepository, AuthRepository>();
            services.AddSingleton<IAuthenticationService, TAuthService>();
        }
    }
    public partial class ModuleInitializer
    {
        public override void AddApis(IServiceCollection services)
        {
            base.AddApis(services);
            services.AddAddRepositories();
        }
    }
}
