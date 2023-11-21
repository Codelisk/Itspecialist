using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;
using Itspecialist.Api;
using Itspecialist.Foundation.Enums.Account;
using ModuleAccount.Contracts.Services.AccountProvider;
using ReactiveUI;

namespace ModuleAccount.Contracts.ViewModels
{
    public partial class TalentProfileSetupViewModel : RegionBaseViewModel
    {
        private readonly ITalentProfileRepository _talentProfileRepository;
        private readonly ITalentCompensationRepository _talentCompensationRepository;
        private readonly IAccountProvider _accountProvider;

        public TalentProfileSetupViewModel(
            VmServices vmServices, 
            ITalentProfileRepository talentProfileRepository,
            ITalentCompensationRepository talentCompensationRepository,
            IAccountProvider accountProvider) : base(vmServices)
        {
            _talentProfileRepository = talentProfileRepository;
            _talentCompensationRepository = talentCompensationRepository;
            _accountProvider = accountProvider;
        }
        private TalentProfileDto talentProfile;
        public TalentProfileDto TalentProfile
        {
            get { return talentProfile; }
            set { this.RaiseAndSetIfChanged(ref talentProfile, value); }
        }
        public TalentCompensationDto TalentCompensation { get; set; }
        public override async void Initialize(NavigationContext navigationContext)
        {
            base.Initialize(navigationContext);

            var account = _accountProvider.Account!;

            var talentProfiles = await _talentProfileRepository.GetAll();
            if (talentProfiles.Any())
            {
                TalentProfile = talentProfiles.Last();
            }
            else
            {
                TalentProfile = new TalentProfileDto
                {
                    Title = "",
                    FirstName = "",
                    LastName = "",
                    id = account.id,
                    PreferredEmploymentStatus = PreferredEmploymentStatusEnum.Contract,
                };
            }


            var talentCompensations = await _talentCompensationRepository.GetAll();
            if (talentCompensations.Any())
            {
                TalentCompensation = talentCompensations.Last();
                TalentProfile.TalentCompensationId = TalentCompensation.id;
            }
            else
            {
                TalentCompensation = new()
                {
                    AccountId = account.id,
                    Type = CompensationTypeEnum.Salary,
                    Wage = 0,
                };
            }


        }

        public ICommand SaveTalentProfileCommand => this.LoadingCommand(OnSaveTalentProfileAsync);
        private async Task OnSaveTalentProfileAsync()
        {
            TalentCompensation = await _talentCompensationRepository.Save(TalentCompensation);
            TalentProfile.TalentCompensationId = TalentCompensation.id;
            await _talentProfileRepository.Save(TalentProfile);
            this.ChangeCurrentRegion("TalentOverview");
        }
    }
}
