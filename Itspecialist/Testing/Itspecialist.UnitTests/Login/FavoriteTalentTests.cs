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
            for (int i = 0; i < 10; i++)
            {
                var account = await RegisterNewAccount($"account{i}@email.at");
                await TalentProfileCreation(account, $"Max{i}", $"Mustermann{i}", $"Software developer{i}");
                TestHttpContext.UserId = Guid.NewGuid();
            }
        }
        [Fact]
        public async Task TalentListOverview()
        {
            await Setup();
            var talents = await _talentProfileManager.GetAll();
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
