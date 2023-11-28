using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Foundation.Enums.Account;
using Itspecialist.Managers;
using Itspecialist.Testbase;
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
            var district = await _districtManager.Add(new DistrictDto { Name = "Gmunden" });
            await _districtManager.Save(district);

            await _programmingLanguageManager.Add(
                new ProgrammingLanguageDto { Name = "C#" }
                );
            await _programmingLanguageManager.Add(
                new ProgrammingLanguageDto { Name = "Java" }
                );
            var programmingLanguages = await _programmingLanguageManager.GetAll();

            await _programmingFrameworkManager.Add(
                new ProgrammingFrameworkDto { ProgrammingLanguageId = programmingLanguages.First().id, Name = ".NET Core" }
                );
            await _programmingFrameworkManager.Add(
                new ProgrammingFrameworkDto { ProgrammingLanguageId = programmingLanguages.First().id, Name = ".NET MAUI" }
                );
        }

        public async Task<AccountDto> RegisterNewAccount(string email)
        {
            //DistrictSelection
            var allDistricts = await _districtManager.GetAll();
            var district = allDistricts.First();

            //ProgrammingLanguageSelection and FrameworkSelection
            var allProgrammingLanguages = await _programmingLanguageManager.GetAll();
            var allProgrammingFrameworks = await _programmingFrameworkManager.GetAll();
            var primaryProgrammingLanguage = allProgrammingLanguages.First();
            var secondaryProgrammingLanguage = allProgrammingLanguages.Last();
            List<ProgrammingFrameworkDto> primaryProgrammingFrameworks = new List<ProgrammingFrameworkDto>()
            {
                allProgrammingFrameworks.First(x=>x.ProgrammingLanguageId == primaryProgrammingLanguage.id),
                allProgrammingFrameworks.Last(x=>x.ProgrammingLanguageId == primaryProgrammingLanguage.id),
            };

            var skill = new SkillsDto
            {
                AccountId = Guid.Empty,
                PrimaryProgrammingLanguage = primaryProgrammingLanguage.id,
                SecondaryProgrammingLanguage = secondaryProgrammingLanguage.id
            };

            //AccountTypeSelection
            var accountType = AccountTypeEnum.Talent;
            _accountSetupProvider.AccountType = accountType;

            //RegisterPage
            var password = "Test1234!";
            var account = new AccountDto
            {
                DistrictId = district.id,
                AccountType = accountType,
                Email = email,
                Name = password
            };
            account = await _accountManager.Add(account);

            await PostRegisterAccountSetup(account, skill, primaryProgrammingFrameworks);

            return account;
        }


        public async Task PostRegisterAccountSetup(AccountDto account, SkillsDto skill, List<ProgrammingFrameworkDto> primaryProgrammingFrameworks, List<ProgrammingFrameworkDto> secondaryProgrammingFrameworks = null)
        {
            skill.AccountId = account.id;
            await _skillsManager.Add(skill);

            foreach (var item in primaryProgrammingFrameworks)
            {
                await _accountProgrammingFrameworkManager.Add(new AccountProgrammingFrameworkDto
                {
                    AccountId = account.id,
                    ProgrammingFrameworkId = item.id
                });
            }
            if (secondaryProgrammingFrameworks is not null)
            {
                foreach (var item in secondaryProgrammingFrameworks!)
                {
                    await _accountProgrammingFrameworkManager.Add(new AccountProgrammingFrameworkDto
                    {
                        AccountId = account.id,
                        ProgrammingFrameworkId = item.id
                    });
                }
            }
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
        }
    }
}
