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
            base.Initialize(navigationContext);

            TalentProfiles = await _talentProfileRepository.GetAllFull();
            this.RaisePropertyChanged(nameof(TalentProfiles));
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
