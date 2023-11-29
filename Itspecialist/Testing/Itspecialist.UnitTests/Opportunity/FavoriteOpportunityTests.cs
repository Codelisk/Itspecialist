using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Foundation.Enums.Account;
using Itspecialist.Testbase.Helpers.Services.Opportunity;
using Itspecialist.Testbase.Mocks;
using Itspecialist.UnitTests.Base;

namespace Itspecialist.UnitTests.Opportunity
{
    public class FavoriteOpportunityTests : BaseUnitTest
    {
        private readonly IOpportunityProfileCreationService _opportunityProfileCreationService;

        public FavoriteOpportunityTests(IOpportunityProfileCreationService opportunityProfileCreationService)
        {
            _opportunityProfileCreationService = opportunityProfileCreationService;
        }
        public override async Task Setup()
        {
            await SetupDefaultDatabaseTables();
            for (int i = 0; i < 10; i++)
            {
                var account = await RegisterNewAccount($"account{i}@email.at");
                await _opportunityProfileCreationService.OpportunityProfileCreation(account, $"Ausschreibung{i}", $"description{i}", PreferredEmploymentStatusEnum.Both);
                TestHttpContext.UserId = Guid.NewGuid();
            }
        }
        [Fact]
        public async Task Test()
        {
            await Setup();
            var opportunities = await _careerOpportunityManager.GetAll();
        }
    }
}
