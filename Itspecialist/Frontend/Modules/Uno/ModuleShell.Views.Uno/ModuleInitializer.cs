using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleShell.Contracts;
using ModuleShell.Contracts.ViewModels.Headers;
using ModuleShell.Views.Uno.Views.Headers;

namespace ModuleShell.Views.Uno
{
    public partial class ModuleInitializer : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.AddModuleShell();
            containerRegistry.RegisterForNavigation<ShellHeader, ShellHeaderViewModel>();
        }
    }
}
