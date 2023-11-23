using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;

namespace ModuleList.Contracts.ViewModels.Talent
{
    public partial class FavoriteTalentOverviewViewModel : RegionBaseViewModel
    {
        public FavoriteTalentOverviewViewModel(VmServices vmServices) : base(vmServices)
        {
        }
    }
}
