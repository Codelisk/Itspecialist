using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleList.Contracts.ViewModels.Talent;
using ModuleList.Views.Uno.Views.Talent;

namespace ModuleList.Views.Uno
{
    public class ModuleInitializer : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<FavoriteTalentOverview, FavoriteTalentOverviewViewModel>();
            containerRegistry.RegisterForNavigation<FavoriteTalentOverview, FavoriteTalentOverviewViewModel>();
        }
    }
}
