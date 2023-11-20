using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;
using BaseSharedModule.Constants;
using Itspecialist.Foundation.Enums.Account;
using ModuleAccount.Contracts.Services.AccountSetup;

namespace ModuleAccount.Contracts.ViewModels
{
    public partial class ChooseAccountTypeViewModel : RegionBaseViewModel
    {
        private readonly IAccountSetupProvider _accountSetupProvider;

        public ChooseAccountTypeViewModel(VmServices vmServices, IAccountSetupProvider accountSetupProvider) : base(vmServices)
        {
            _accountSetupProvider = accountSetupProvider;
        }

        public AccountTypeEnum SelectedAccountType { get; set; }
        public List<AccountTypeEnum> AccountTypes { get; set; }

        public ICommand FinishedCommand => this.LoadingCommand(OnFinishedAsync);
        private async Task OnFinishedAsync()
        {
            _accountSetupProvider.AccountType = SelectedAccountType;
            this.ChangeCurrentRegion("RegisterPage");
        }
    }
}
