using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;
using Itspecialist.Foundation.Enums.Account;

namespace ModuleAccount.Contracts.ViewModels
{
    public partial class ChooseAccountTypeViewModel : RegionBaseViewModel
    {
        public ChooseAccountTypeViewModel(VmServices vmServices) : base(vmServices)
        {
        }

        public List<AccountTypeEnum> AccountTypes { get; set; }

        public ICommand FinishedCommand => this.LoadingCommand(OnFinishedAsync);
        private async Task OnFinishedAsync()
        {

        }
    }
}
