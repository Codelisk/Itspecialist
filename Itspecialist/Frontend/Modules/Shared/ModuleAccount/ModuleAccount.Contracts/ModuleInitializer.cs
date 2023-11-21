using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
