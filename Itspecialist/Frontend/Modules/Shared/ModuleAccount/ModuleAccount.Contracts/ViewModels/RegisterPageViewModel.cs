using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;
using Itspecialist.Api.Repositories;
using Itspecialist.Api.Services.Auth;
using ModuleAccount.Contracts.Services.AccountProvider;
using ModuleAccount.Contracts.Services.AccountSetup;

namespace ModuleAccount.Contracts.ViewModels
{
    public partial class RegisterPageViewModel : RegionBaseViewModel
    {
        private readonly IAccountProvider _accountProvider;
        private readonly IAccountSetupProvider _accountSetupProvider;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountRepository _accountRepository;

        public RegisterPageViewModel(VmServices vmServices,
            IAccountProvider accountProvider,
            IAccountSetupProvider accountSetupProvider,
            IAuthenticationService authenticationService,
            IAccountRepository accountRepository) : base(vmServices)
        {
            _accountProvider = accountProvider;
            _accountSetupProvider = accountSetupProvider;
            _authenticationService = authenticationService;
            _accountRepository = accountRepository;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand RegisterCommand => this.LoadingCommand(OnRegisterAsync);
        private async Task OnRegisterAsync()
        {
            await _authenticationService.RegisterAsync(Email, Password);
            var account = new AccountDto()
            {
                Name = Name,
                Email = Email,
                AccountType = _accountSetupProvider.AccountType!.Value,
                DistrictId = _accountSetupProvider.District!.id,
                SkillsId = _accountSetupProvider.Skill!.id,
            };

            account = await _accountRepository.Save(account);
            _accountProvider.SetAccountFromRegister(account);

            //TODO Implement depending on account type
            ChangeCurrentRegion("TalentProfile");
        }
    }
}
