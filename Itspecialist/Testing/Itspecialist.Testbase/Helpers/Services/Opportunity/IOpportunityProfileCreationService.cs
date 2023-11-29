using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Foundation.Enums.Account;

namespace Itspecialist.Testbase.Helpers.Services.Opportunity
{
    public interface IOpportunityProfileCreationService
    {
        Task<CareerOpportunityDto> OpportunityProfileCreation(AccountDto account, string title, string description, PreferredEmploymentStatusEnum preferredEmploymentStatusEnum);
    }
}
