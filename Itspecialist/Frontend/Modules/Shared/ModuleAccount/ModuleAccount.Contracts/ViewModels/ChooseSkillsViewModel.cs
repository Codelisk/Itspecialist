using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;

namespace ModuleAccount.Contracts.ViewModels
{
    public partial class ChooseSkillsViewModel : RegionBaseViewModel
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IProgrammingFrameworkRepository _programmingFrameworkRepository;

        public ChooseSkillsViewModel(VmServices vmServices,
            IProgrammingLanguageRepository programmingLanguageRepository,
            IProgrammingFrameworkRepository programmingFrameworkRepository) : base(vmServices)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingFrameworkRepository = programmingFrameworkRepository;
        }

        public List<ProgrammingLanguageDto> ProgrammingLanguages { get; set; }
        public List<ProgrammingFrameworkDto> AllProgrammingFrameworks { get; set; }
        public override async void Initialize(NavigationContext navigationContext)
        {
            base.Initialize(navigationContext);
            try
            {
                ProgrammingLanguages = await _programmingLanguageRepository.GetAll();
                AllProgrammingFrameworks = await _programmingFrameworkRepository.GetAll();
            }catch(Exception e) { }
        }
    }
}
