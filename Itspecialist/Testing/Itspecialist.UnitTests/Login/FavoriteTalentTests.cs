using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Foundation.Enums.Account;
using Itspecialist.Testbase.Mocks;
using Itspecialist.UnitTests.Base;

namespace Itspecialist.UnitTests.Login
{
    public class FavoriteTalentTests : BaseUnitTest
    {
        public override async Task Setup()
        {
            await SetupDefaultDatabaseTables();
            await RegisterNewAccount("account1@email.at");
            TestHttpContext.UserId = Guid.NewGuid();
            await RegisterNewAccount("account2@email.at");
            TestHttpContext.UserId = Guid.NewGuid();
            await RegisterNewAccount("account3@email.at");
        }
        [Fact]
        public async Task TalentListOverview()
        {
            await Setup();

        }
        private async Task TalentProfileCreation(AccountDto account, string firstname = "Max", string lastname= "Mustermann", string title= "Software Developer")
        {
            var skill = await _skillsManager.Get(account.id);
            var talentCompensation = await _talentCompensationManager.Add(new TalentCompensationDto
            {
                AccountId = account.id,
                Type = CompensationTypeEnum.Hourly,
                Wage = 80
            });

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
