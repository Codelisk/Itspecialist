using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Foundation.Enums.Account;
using Itspecialist.Foundation.Helper;
using Itspecialist.Managers;

namespace Itspecialist.Testbase.Helpers.Services.Opportunity
{
    internal class OpportunityProfileCreationService : IOpportunityProfileCreationService
    {
        private readonly ISkillsManager _skillsManager;
        private readonly ICareerOpportunityManager _careerOpportunityManager;
        private readonly ICompanyManager _companyManager;

        public OpportunityProfileCreationService(
            ISkillsManager skillsManager, 
            ICareerOpportunityManager careerOpportunityManager,
            ICompanyManager companyManager)
        {
            _skillsManager = skillsManager;
            _careerOpportunityManager = careerOpportunityManager;
            _companyManager = companyManager;
        }
        public async Task<CareerOpportunityDto> OpportunityProfileCreation(AccountDto account, string title, string description, PreferredEmploymentStatusEnum preferredEmploymentStatusEnum)
        {
            var skill = await _skillsManager.Get(account.id);
            var company = await _companyManager.Get(account.id);

            //Save
            return await _careerOpportunityManager.Add(new CareerOpportunityDto
            {
                Title = title,
                CompanyId=company.GetId(),
                PreferredEmploymentStatus = preferredEmploymentStatusEnum,
                CreatedDate = DateTimeHelper.Now(),
                DistrictId = account.DistrictId,
                SkillsId = skill.GetId(),
                Description = description
            });
        }
    }
}
