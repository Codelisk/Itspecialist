using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Foundation.Enums.Account;
using Itspecialist.Testbase.Helpers.Services.Account;
using Itspecialist.Testbase.Helpers.Services.Talent;
using Itspecialist.Testbase.Mocks;
using Itspecialist.UnitTests.Base;

namespace Itspecialist.UnitTests.Talents
{
    public class FavoriteTalentTests : BaseUnitTest
    {
        private readonly ITalentProfileCreationService _talentProfileCreationService;

        public FavoriteTalentTests(ITalentProfileCreationService talentProfileCreationService)
        {
            _talentProfileCreationService = talentProfileCreationService;
        }
        public override async Task Setup()
        {
            await SetupDefaultDatabaseTables();
            for (int i = 0; i < 10; i++)
            {
                var account = await RegisterNewAccount($"account{i}@email.at");
                await _talentProfileCreationService.TalentProfileCreation(account, $"Max{i}", $"Mustermann{i}", $"Software developer{i}");
                TestHttpContext.UserId = Guid.NewGuid();
            }
        }
        [Fact]
        public async Task TalentListOverview()
        {
            await Setup();
            var talents = await _talentProfileManager.GetAll();
        }
    }
}
