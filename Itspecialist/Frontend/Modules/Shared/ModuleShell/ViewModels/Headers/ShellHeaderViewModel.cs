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

        public ICommand JobCommand => this.LoadingCommand(OnJobAsync);
        private async Task OnJobAsync()
        {
            await _shellNavigatorService.NavigateToJobsAsync(_vmServices.RegionManager);
        }
    }
}
