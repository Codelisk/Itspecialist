using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;
using BaseSharedModule.Constants;
using ModuleAccount.Contracts.Services.AccountSetup;

namespace ModuleAccount.Contracts.ViewModels
{
    public partial class ChooseSkillsViewModel : RegionBaseViewModel
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IProgrammingFrameworkRepository _programmingFrameworkRepository;
        private readonly IAccountSetupProvider _accountSetupProvider;

        public ChooseSkillsViewModel(VmServices vmServices,
            IProgrammingLanguageRepository programmingLanguageRepository,
            IProgrammingFrameworkRepository programmingFrameworkRepository,
            IAccountSetupProvider accountSetupProvider) : base(vmServices)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingFrameworkRepository = programmingFrameworkRepository;
            _accountSetupProvider = accountSetupProvider;
        }

        public List<ProgrammingLanguageDto> Languages { get; set; }
        public List<ProgrammingFrameworkDto> AllFrameworks { get; set; }
        public ProgrammingLanguageDto PrimaryLanguage { get; set; }
        public List<ProgrammingFrameworkDto> PrimaryFrameworks { get; set; }
        public ProgrammingLanguageDto SecondaryLanguage { get; set; }
        public List<ProgrammingFrameworkDto> SecondaryFrameworks { get; set; }
        public override async void Initialize(NavigationContext navigationContext)
        {
            base.Initialize(navigationContext);
            try
            {
                Languages = await _programmingLanguageRepository.GetAll();
                AllFrameworks = await _programmingFrameworkRepository.GetAll();

                PrimaryLanguage = Languages.First(x => x.Name.Equals("C#"));
                PrimaryFrameworks = AllFrameworks.Where(x => x.ProgrammingLanguageId == PrimaryLanguage.id).ToList();
                SecondaryLanguage = Languages.First(x => x.Name.Equals("Java"));
                SecondaryFrameworks = AllFrameworks.Where(x => x.ProgrammingLanguageId == SecondaryLanguage.id).ToList();
            }
            catch(Exception e) { }
        }
        public ICommand FinishedCommand => this.LoadingCommand(OnFinishedAsync);
        private async Task OnFinishedAsync()
        {
            var skill=new SkillsDto { AccountId = Guid.Empty, PrimaryProgrammingLanguage = PrimaryLanguage.id, SecondaryProgrammingLanguage = SecondaryLanguage.id };
            _accountSetupProvider.Skill = skill;
            _accountSetupProvider.PrimaryFrameworks = PrimaryFrameworks;
            _accountSetupProvider.SecondaryFrameworks = SecondaryFrameworks;
            this.ChangeCurrentRegion("ChooseAccountType");
        }
    }
}
