using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;

namespace ModuleDashboard.Contracts.ViewModels.Opportunity
{
    public partial class OpportunityOverviewViewModel : RegionBaseViewModel
    {
        public OpportunityOverviewViewModel(VmServices vmServices) : base(vmServices)
        {
        }
    }
}
