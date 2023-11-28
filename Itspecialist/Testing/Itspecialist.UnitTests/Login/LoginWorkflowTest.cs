using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Foundation.Enums.Account;
using Itspecialist.Managers;
using Itspecialist.Testbase;
using Itspecialist.UnitTests.Base;
using ModuleAccount.Contracts.Services.AccountSetup;

namespace Itspecialist.UnitTests.Login
{
    public class LoginWorkflowTest : BaseUnitTest
    {
        public override async Task Setup()
        {
            await SetupDefaultDatabaseTables();
        }

        [Fact]
        public async Task Workflow()
        {
            await Setup();
            //DistrictSelection
            var allDistricts = await _districtManager.GetAll();
            var district = allDistricts.First();
            _accountSetupProvider.District = district;

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

            _accountSetupProvider.PrimaryFrameworks = primaryProgrammingFrameworks;
            _accountSetupProvider.SecondaryFrameworks = null;
            _accountSetupProvider.Skill =new SkillsDto
            {
                AccountId = Guid.Empty,
                PrimaryProgrammingLanguage = primaryProgrammingLanguage.id,
                SecondaryProgrammingLanguage = secondaryProgrammingLanguage.id
            };

            //AccountTypeSelection
            var accountType = AccountTypeEnum.Talent;
            _accountSetupProvider.AccountType = accountType;

            //RegisterPage
            var email = "email@test.at";
            var password = "Test1234!";
            var account = new AccountDto
            {
                DistrictId = district.id,
                AccountType = accountType,
                Email = email,
                Name = password
            };
            account = await _accountManager.Add(account);
            _accountSetupProvider.Skill.AccountId = account.id;
            await _skillsManager.Add(_accountSetupProvider.Skill);

            await PostRegisterAccountSetup(account, _accountSetupProvider.Skill, _accountSetupProvider.PrimaryFrameworks!, _accountSetupProvider.SecondaryFrameworks);

            //TalentProfile creation
            await TalentProfileCreation();

            await SelectTalentsToList();
        }

        private async Task SelectTalentsToList()
        {
            var talents = await _talentProfileManager.GetAllFull();

            var favoriteTalent = await _favoriteTalentManager.Add(new FavoriteTalentDto
            {
                AccountId = Guid.Empty,
                TalentProfileId = (talents.First() as TalentProfileFull).talentProfileDto.GetId()
            });
        }


        private async Task TalentProfileCreation()
        {
            //Values to load on init
            var accounts = await _accountManager.GetAll();
            var account = accounts.Last();
            var skills = await _skillsManager.GetAll();
            var skill = skills.First();
            var talentCompensation = await _talentCompensationManager.Add(new TalentCompensationDto
            {
                AccountId = account.id,
                Type = CompensationTypeEnum.Hourly,
                Wage = 80
            });

            //Values to choose
            string firstname = "Max";
            string lastname = "Mustermann";
            string title = "Software Developer";

            //Save
            await _talentProfileManager.Add(new TalentProfileDto
            {
                AccountId = account.id,
                FirstName = firstname,
                LastName = lastname,
                PreferredEmploymentStatus = PreferredEmploymentStatusEnum.Both,
                Title = title,
                DistrictId = account.DistrictId,
                SkillsId = skill.GetId(),
                TalentCompensationId = talentCompensation.id
            });
        }
    }
}
