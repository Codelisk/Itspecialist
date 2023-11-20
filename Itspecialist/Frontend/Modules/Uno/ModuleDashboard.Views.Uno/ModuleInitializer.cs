using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleDashboard.Contracts.ViewModels.Opportunity;
using ModuleDashboard.Contracts.ViewModels.Talent;
using ModuleDashboard.Views.Uno.Views.Opportunity;
using ModuleDashboard.Views.Uno.Views.Talent;

namespace ModuleDashboard.Views.Uno
{
    public class ModuleInitializer : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<OpportunityOverview, OpportunityOverviewViewModel>();
            containerRegistry.RegisterForNavigation<TalentOverview, TalentOverviewViewModel>();
        }
    }
}
