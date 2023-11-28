using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ModuleAccount.Contracts.Services.AccountProvider;
using ModuleAccount.Contracts.Services.AccountSetup;

namespace ModuleAccount.Contracts
{
    public static partial class ModuleInitializer
    {
        public static void AddModuleAccountContracts(this IContainerRegistry containerRegistry)
        {
            containerRegistry.TryRegisterSingleton<IAccountProvider, AccountProvider>();
            containerRegistry.TryRegisterSingleton<IAccountSetupProvider, AccountSetupProvider>();
        }
        public static void AddModuleAccountContracts(this IServiceCollection services)
        {
            services.TryAddSingleton<IAccountProvider, AccountProvider>();
            services.TryAddSingleton<IAccountSetupProvider, AccountSetupProvider>();
        }
    }
}
