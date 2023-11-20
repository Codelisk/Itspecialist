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
        public TalentProfileDto TalentProfile { get; set; }
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
                    AccountId = account.id,
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
            await _talentCompensationRepository.Save(TalentCompensation);
            await _talentProfileRepository.Save(TalentProfile);
        }
    }
}
