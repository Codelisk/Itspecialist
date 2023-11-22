using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;

namespace ModuleShell.Contracts.ViewModels.Headers
{
    public partial class ShellHeaderViewModel : RegionBaseViewModel
    {
        private readonly VmServices _vmServices;
        private readonly IShellNavigatorService _shellNavigatorService;

        public ShellHeaderViewModel(VmServices vmServices, IShellNavigatorService shellNavigatorService) : base(vmServices)
        {
            _vmServices = vmServices;
            _shellNavigatorService = shellNavigatorService;
        }

        public ICommand OpportunityCommand => this.LoadingCommand(OnOpportunityAsync);
        private async Task OnOpportunityAsync()
        {
            await _shellNavigatorService.NavigateToJobsAsync(_vmServices.RegionManager);
        }

        public ICommand TalentCommand => this.LoadingCommand(OnTalentAsync);
        private async Task OnTalentAsync()
        {
            await _shellNavigatorService.NavigateToTalentsAsync(_vmServices.RegionManager);
        }
        public ICommand SetupCommand => this.LoadingCommand(OnSetupAsync);
        private async Task OnSetupAsync()
        {
            _vmServices.RegionManager.RequestNavigate("ContentRegion", "DistrictSelection");
        }
    }
}
