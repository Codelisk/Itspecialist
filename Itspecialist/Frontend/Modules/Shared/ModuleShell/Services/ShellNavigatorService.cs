using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleShell.Contracts.Services
{
    internal class ShellNavigatorService : IShellNavigatorService
    {
        public async Task NavigateToJobsAsync<TNavigator>(TNavigator navigator)
        {
            if(navigator is IRegionManager regionManager)
            {
                regionManager.RequestNavigate("ContentRegion", "OpportunityOverview");
            }
        }
        public async Task NavigateToTalentsAsync<TNavigator>(TNavigator navigator)
        {
            if (navigator is IRegionManager regionManager)
            {
                regionManager.RequestNavigate("ContentRegion", "TalentOverview");
            }
        }
    }
}
