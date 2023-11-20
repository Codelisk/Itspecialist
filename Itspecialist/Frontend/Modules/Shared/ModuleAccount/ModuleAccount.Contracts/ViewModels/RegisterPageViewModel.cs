using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;

namespace ModuleAccount.Contracts.ViewModels
{
    public partial class RegisterPageViewModel : RegionBaseViewModel
    {
        public RegisterPageViewModel(VmServices vmServices) : base(vmServices)
        {
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
