using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;
using Itspecialist.Foundation.DtoHelper;
using Itspecialist.Api;
using System.Windows.Input;
using ModuleAccount.Contracts.Services.AccountProvider;
using Itspecialist.Api.Services.Auth;
using ReactiveUI;

namespace ModuleDashboard.Contracts.ViewModels.Talent
{
    public partial class TalentOverviewViewModel : RegionBaseViewModel
    {
        private readonly ITalentCompensationRepository _talentCompensationRepository;
        private readonly ITalentProfileRepository _talentProfileRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IProgrammingFrameworkRepository _programmingFrameworkRepository;
        private readonly ISkillsRepository _skillsRepository;
        private readonly IAccountProgrammingFrameworkRepository _accountProgrammingFrameworkRepository;
        private readonly IAccountProvider _accountProvider;
        private readonly IAuthenticationService _authenticationService;
        private readonly IDistrictRepository _districtRepository;
        private readonly IAccountRepository _accountRepository;

        public TalentOverviewViewModel(VmServices vmServices,
            ITalentCompensationRepository talentCompensationRepository,
            ITalentProfileRepository talentProfileRepository,
            IProgrammingLanguageRepository programmingLanguageRepository,
            IProgrammingFrameworkRepository programmingFrameworkRepository,
            ISkillsRepository skillsRepository,
            IAccountProgrammingFrameworkRepository accountProgrammingFrameworkRepository,
            IAccountProvider accountProvider,
            IAuthenticationService authenticationService,
            IDistrictRepository districtRepository,
            IAccountRepository accountRepository) : base(vmServices)
        {
            _talentCompensationRepository = talentCompensationRepository;
            _talentProfileRepository = talentProfileRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingFrameworkRepository = programmingFrameworkRepository;
            _skillsRepository = skillsRepository;
            _accountProgrammingFrameworkRepository = accountProgrammingFrameworkRepository;
            _accountProvider = accountProvider;
            _authenticationService = authenticationService;
            _districtRepository = districtRepository;
            _accountRepository = accountRepository;
        }

        public List<TalentProfileFull> TalentProfiles { get; set; }
        public AccountFull Account { get; set; }
        public override async void Initialize(NavigationContext navigationContext)
        {
            try
            {

                base.Initialize(navigationContext);

                await _authenticationService.AuthenticateAndCacheTokenAsync(new Foundation.Api.Models.AuthPayload
                {
                    email = "d.hufnagl@codelisk.com",
                    password = "Test1234!"
                });
                await _accountProvider.SetAccountAsync();

                var accounts = await _accountRepository.GetAll();
                var districts = await _districtRepository.GetAll();
                List<TalentCompensationDto> talentCompensationsDtos = await _talentCompensationRepository.GetAll();
                List<TalentProfileDto> talentProfilesDtos = await _talentProfileRepository.GetAll();
                var languages = await _programmingLanguageRepository.GetAll();
                var frameworks = await _programmingFrameworkRepository.GetAll();
                var accountProgrammingFrameworks = await _accountProgrammingFrameworkRepository.GetAll();
                var skills = await _skillsRepository.GetAll();
                var skill = skills.First(x => x.AccountId == _accountProvider.Account!.id);
                Account = new AccountFull(_accountProvider.Account!,
                    languages.First(x => x.id == skill.PrimaryProgrammingLanguage),
                    languages.First(x => x.id == skill.SecondaryProgrammingLanguage),
                    frameworks.Where(x => accountProgrammingFrameworks.Any(y => y.ProgrammingFrameworkId == x.id && x.ProgrammingLanguageId == skill.PrimaryProgrammingLanguage)).ToList(),
                    frameworks.Where(x => accountProgrammingFrameworks.Any(y => y.ProgrammingFrameworkId == x.id && x.ProgrammingLanguageId == skill.SecondaryProgrammingLanguage)).ToList());

                TalentProfiles = talentProfilesDtos.Select(x => new TalentProfileFull(x, talentCompensationsDtos.FirstOrDefault(y => y.id == x.TalentCompensationId), districts.FirstOrDefault(y=>y.id == x.DistrictId))).ToList();

                this.RaisePropertyChanged(nameof(TalentProfiles));
            }
            catch (Exception ex) { }
        }

        public ICommand LoadTalentsCommand => this.LoadingCommand(OnLoadTalentsAsync);
        private async Task OnLoadTalentsAsync()
        {
            List<TalentCompensationDto> talentCompensationsDtos = await _talentCompensationRepository.GetAll();
            List<TalentProfileDto> talentProfilesDtos = await _talentProfileRepository.GetAll();
            this.GoRegionBack();
        }
    }
}
