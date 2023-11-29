using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Testbase.Helpers.Services.Setup;
using ModuleAccount.Contracts.Services.AccountSetup;
using Itspecialist.Managers;
using Itspecialist.Foundation.Enums.Account;

namespace Itspecialist.Testbase.Helpers.Services.Account
{
    internal class AccountCreationService : IAccountCreationService
    {
        public readonly IDistrictManager _districtManager;
        public readonly IProgrammingFrameworkManager _programmingFrameworkManager;
        public readonly IProgrammingLanguageManager _programmingLanguageManager;
        public readonly IAccountManager _accountManager;
        public readonly IAccountCompensationManager _accountCompensationManager;
        public readonly IAccountProgrammingFrameworkManager _accountProgrammingFrameworkManager;
        public readonly ITalentProfileManager _talentProfileManager;
        public readonly ITalentCompensationManager _talentCompensationManager;
        public readonly ISkillsManager _skillsManager;
        public readonly IFavoriteTalentManager _favoriteTalentManager;
        public readonly IOpportunityProgrammingFrameworkManager _opportunityProgrammingFrameworkManager;
        public readonly ICareerOpportunityManager _careerOpportunityManager;
        public readonly IAccountSetupProvider _accountSetupProvider;
        public readonly IDatabaseSetupService _databaseSetupService;

        public AccountCreationService(IDistrictManager districtManager,
                         IProgrammingFrameworkManager programmingFrameworkManager,
                         IProgrammingLanguageManager programmingLanguageManager,
                         IAccountManager accountManager,
                         IAccountCompensationManager accountCompensationManager,
                         IAccountProgrammingFrameworkManager accountProgrammingFrameworkManager,
                         ITalentProfileManager talentProfileManager,
                         ITalentCompensationManager talentCompensationManager,
                         ISkillsManager skillsManager,
                         IFavoriteTalentManager favoriteTalentManager,
                         IOpportunityProgrammingFrameworkManager opportunityProgrammingFrameworkManager,
                         ICareerOpportunityManager careerOpportunityManager,
                         IAccountSetupProvider accountSetupProvider,
                         IDatabaseSetupService databaseSetupService)
        {
            _districtManager = districtManager;
            _programmingFrameworkManager = programmingFrameworkManager;
            _programmingLanguageManager = programmingLanguageManager;
            _accountManager = accountManager;
            _accountCompensationManager = accountCompensationManager;
            _accountProgrammingFrameworkManager = accountProgrammingFrameworkManager;
            _talentProfileManager = talentProfileManager;
            _talentCompensationManager = talentCompensationManager;
            _skillsManager = skillsManager;
            _favoriteTalentManager = favoriteTalentManager;
            _opportunityProgrammingFrameworkManager = opportunityProgrammingFrameworkManager;
            _careerOpportunityManager = careerOpportunityManager;
            _accountSetupProvider = accountSetupProvider;
            _databaseSetupService = databaseSetupService;
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

    }
}
