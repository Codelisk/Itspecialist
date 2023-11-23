using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;
using Itspecialist.Api.Services.Auth;

namespace ModuleShell.Contracts.ViewModels.Headers
{
    public partial class ShellHeaderViewModel : RegionBaseViewModel
    {
        private readonly VmServices _vmServices;
        private readonly IAuthenticationService _authenticationService;
        private readonly IShellNavigatorService _shellNavigatorService;

        public ShellHeaderViewModel(VmServices vmServices, IAuthenticationService authenticationService, IShellNavigatorService shellNavigatorService) : base(vmServices)
        {
            _vmServices = vmServices;
            _authenticationService = authenticationService;
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

        public ICommand LoginCommand => this.LoadingCommand(OnLoginAsync);
        private async Task OnLoginAsync()
        {
            await _authenticationService.AuthenticateAndCacheTokenAsync(new Foundation.Api.Models.AuthPayload
            {
                email = "d.hufnagl@codelisk.com",
                password = "Test1234!"
            });
        }
    }
}
