using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Foundation.Enums.Account;
using Itspecialist.Testbase.Mocks;
using Itspecialist.UnitTests.Base;

namespace Itspecialist.UnitTests.Opportunity
{
    public class FavoriteOpportunityTests : BaseUnitTest
    {
        public override async Task Setup()
        {
            await SetupDefaultDatabaseTables();
            for (int i = 0; i < 10; i++)
            {
                var account = await RegisterNewAccount($"account{i}@email.at");
                await OpportunityProfileCreation(account,$"description{i}");
                TestHttpContext.UserId = Guid.NewGuid();
            }
        }
        private async Task OpportunityProfileCreation(AccountDto account, string description)
        {
            var skill = await _skillsManager.Get(account.id);

            //Save
            await _careerOpportunityManager.Add(new CareerOpportunityDto
            {
                DistrictId = account.DistrictId,
                SkillsId = skill.GetId(),
                Description = description
            });
        }
        [Fact]
        public async Task Test()
        {
            await Setup();
            var opportunities = await _careerOpportunityManager.GetAll();
        }
    }
}
