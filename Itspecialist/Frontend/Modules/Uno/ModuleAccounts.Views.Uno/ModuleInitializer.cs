using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleAccount.Contracts.ViewModels;
using ModuleAccounts.Views.Uno.Views;
using ModuleAccount.Contracts;

namespace ModuleAccounts.Views.Uno
{
    public class ModuleInitializer : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleInitializer(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.AddModuleAccountContracts();
            containerRegistry.RegisterForNavigation<DistrictSelection, DistrictSelectionViewModel>();
            containerRegistry.RegisterForNavigation<ChooseSkills, ChooseSkillsViewModel>();
            containerRegistry.RegisterForNavigation<ChooseAccountType, ChooseAccountTypeViewModel>();
            containerRegistry.RegisterForNavigation<TalentProfileSetup, TalentProfileSetupViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
        }
    }
}
