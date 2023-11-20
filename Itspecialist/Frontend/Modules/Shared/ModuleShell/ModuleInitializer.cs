using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleShell.Contracts
{
    public static class ModuleInitializer
    {
        public static void AddModuleShell(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IShellNavigatorService, ShellNavigatorService>();
        }
    }
}
