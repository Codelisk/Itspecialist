using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;

namespace ModuleAccount.Contracts.ViewModels
{
    public partial class ChooseAccountTypeViewModel : RegionBaseViewModel
    {
        public ChooseAccountTypeViewModel(VmServices vmServices) : base(vmServices)
        {
        }
    }
}
