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
        private readonly IDistrictRepository _districtRepository;

        public TalentProfileSetupViewModel(
            VmServices vmServices, 
            ITalentProfileRepository talentProfileRepository,
            ITalentCompensationRepository talentCompensationRepository,
            IAccountProvider accountProvider,
            IDistrictRepository districtRepository) : base(vmServices)
        {
            _talentProfileRepository = talentProfileRepository;
            _talentCompensationRepository = talentCompensationRepository;
            _accountProvider = accountProvider;
            _districtRepository = districtRepository;
        }
        private TalentProfileDto talentProfile;
        public TalentProfileDto TalentProfile
        {
            get { return talentProfile; }
            set { this.RaiseAndSetIfChanged(ref talentProfile, value); }
        }
        public TalentCompensationDto? TalentCompensation { get; set; }
        public override async void Initialize(NavigationContext navigationContext)
        {
            base.Initialize(navigationContext);

            var account = _accountProvider.Account!;

            var districts = await _districtRepository.GetAll();
            try
            {
                TalentProfile = await _talentProfileRepository.Get(account.id);
            }
            catch(Exception ex)
            {

            }
            if(TalentProfile is null)
            {
                TalentProfile = new TalentProfileDto
                {
                    Title = "",
                    FirstName = "",
                    LastName = "",
                    AccountId = account.id,
                    PreferredEmploymentStatus = PreferredEmploymentStatusEnum.Contract,
                };
            }


            var talentCompensations = await _talentCompensationRepository.GetAll();
            TalentCompensation = talentCompensations.LastOrDefault(x => x.AccountId == account.id);
            if (TalentCompensation is not null)
            {
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

            TalentProfile.DistrictId = districts.First(x=>x.id == account.DistrictId).id;
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
