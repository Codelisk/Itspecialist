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
using ReactiveUI;

namespace ModuleAccount.Contracts.ViewModels
{
    public partial class RegisterPageViewModel : RegionBaseViewModel
    {
        private readonly IAccountProvider _accountProvider;
        private readonly IAccountSetupProvider _accountSetupProvider;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountRepository _accountRepository;
        private readonly ISkillsRepository _skillsRepository;

        public RegisterPageViewModel(VmServices vmServices,
            IAccountProvider accountProvider,
            IAccountSetupProvider accountSetupProvider,
            IAuthenticationService authenticationService,
            IAccountRepository accountRepository,
            ISkillsRepository skillsRepository) : base(vmServices)
        {
            _accountProvider = accountProvider;
            _accountSetupProvider = accountSetupProvider;
            _authenticationService = authenticationService;
            _accountRepository = accountRepository;
            _skillsRepository = skillsRepository;
        }

        private string email;
        public string Email
        {
            get => email;
            set => this.RaiseAndSetIfChanged(ref email, value);
        }

        private string name;
        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { this.RaiseAndSetIfChanged(ref password, value); }
        }

        public ICommand RegisterCommand => this.LoadingCommand(OnRegisterAsync);
        private async Task OnRegisterAsync()
        {
            await _authenticationService.RegisterAsync(Email, Password);

            var skill = await _skillsRepository.Save(_accountSetupProvider.Skill!);
            var account = new AccountDto()
            {
                Name = Name,
                Email = Email,
                AccountType = _accountSetupProvider.AccountType!.Value,
                DistrictId = _accountSetupProvider.District!.id,
                SkillsId = skill.id,
            };

            account = await _accountRepository.Save(account);
            _accountProvider.SetAccountFromRegister(account);

            //TODO Implement depending on account type
            ChangeCurrentRegion("TalentProfileSetup");
        }
    }
}
