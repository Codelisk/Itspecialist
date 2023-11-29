using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Foundation.Enums.Account;
using Itspecialist.Managers;
using Itspecialist.Testbase;
using Itspecialist.Testbase.Helpers.Services.Account;
using Itspecialist.Testbase.Helpers.Services.Setup;
using ModuleAccount.Contracts.Services.AccountSetup;

namespace Itspecialist.UnitTests.Base
{
    public abstract class BaseUnitTest : BaseTest
    {
        public BaseUnitTest()
        {
            SetupServices();
        }


        public async Task SetupDefaultDatabaseTables()
        {
            await _databaseSetupService.SetupDefaultDatabaseTables();
        }

        public async Task<AccountDto> RegisterNewAccount(string email)
        {
            return await _accountCreationService.RegisterNewAccount(email);
        }


        public async Task PostRegisterAccountSetup(AccountDto account, SkillsDto skill, List<ProgrammingFrameworkDto> primaryProgrammingFrameworks, List<ProgrammingFrameworkDto> secondaryProgrammingFrameworks = null)
        {
            await _accountCreationService.PostRegisterAccountSetup(account, skill, primaryProgrammingFrameworks, secondaryProgrammingFrameworks);
        }

        public abstract Task Setup();

        public IDistrictManager _districtManager;
        public IProgrammingFrameworkManager _programmingFrameworkManager;
        public IProgrammingLanguageManager _programmingLanguageManager;
        public IAccountManager _accountManager;
        public IAccountCompensationManager _accountCompensationManager;
        public IAccountProgrammingFrameworkManager _accountProgrammingFrameworkManager;
        public ITalentProfileManager _talentProfileManager;
        public ITalentCompensationManager _talentCompensationManager;
        public ISkillsManager _skillsManager;
        public IFavoriteTalentManager _favoriteTalentManager;
        public IOpportunityProgrammingFrameworkManager _opportunityProgrammingFrameworkManager;
        public ICareerOpportunityManager _careerOpportunityManager;

        public IAccountSetupProvider _accountSetupProvider;
        public IDatabaseSetupService _databaseSetupService;
        public IAccountCreationService _accountCreationService;
        private void SetupServices()
        {
            _districtManager = GetRequiredService<IDistrictManager>();
            _programmingLanguageManager = GetRequiredService<IProgrammingLanguageManager>();
            _programmingFrameworkManager = GetRequiredService<IProgrammingFrameworkManager>();
            _accountManager = GetRequiredService<IAccountManager>();
            _accountCompensationManager = GetRequiredService<IAccountCompensationManager>();
            _accountProgrammingFrameworkManager = GetRequiredService<IAccountProgrammingFrameworkManager>();
            _talentProfileManager = GetRequiredService<ITalentProfileManager>();
            _talentCompensationManager = GetRequiredService<ITalentCompensationManager>();
            _skillsManager = GetRequiredService<ISkillsManager>();
            _favoriteTalentManager = GetRequiredService<IFavoriteTalentManager>();
            _opportunityProgrammingFrameworkManager = GetRequiredService<IOpportunityProgrammingFrameworkManager>();
            _careerOpportunityManager = GetRequiredService<ICareerOpportunityManager>();

            _accountSetupProvider = GetRequiredService<IAccountSetupProvider>();

            _databaseSetupService = GetRequiredService<IDatabaseSetupService>();
            _accountCreationService = GetRequiredService<IAccountCreationService>();
        }
    }
}
