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

namespace ModuleDashboard.Contracts.ViewModels.Talent
{
    public partial class TalentOverviewViewModel : RegionBaseViewModel
    {
        private readonly ITalentCompensationRepository _talentCompensationRepository;
        private readonly ITalentProfileRepository _talentProfileRepository;

        public TalentOverviewViewModel(VmServices vmServices,
            ITalentCompensationRepository talentCompensationRepository,
            ITalentProfileRepository talentProfileRepository) : base(vmServices)
        {
            _talentCompensationRepository = talentCompensationRepository;
            _talentProfileRepository = talentProfileRepository;
        }

        public List<TalentProfileFull> TalentProfiles { get; set; }
        public override async void Initialize(NavigationContext navigationContext)
        {
            base.Initialize(navigationContext);

            List<TalentCompensationDto> talentCompensationsDtos = await _talentCompensationRepository.GetAll();
            List<TalentProfileDto> talentProfilesDtos = await _talentProfileRepository.GetAll();

            TalentProfiles = talentProfilesDtos.Select(x => new TalentProfileFull(x, talentCompensationsDtos.FirstOrDefault(y => y.id == x.TalentCompensationId))).ToList();
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
