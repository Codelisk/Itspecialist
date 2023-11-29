using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Foundation.Enums.Account;
using Itspecialist.Managers;

namespace Itspecialist.Testbase.Helpers.Services.Talent
{
    internal class TalentProfileCreationService : ITalentProfileCreationService
    {
        private readonly ISkillsManager _skillsManager;
        private readonly ITalentProfileManager _talentProfileManager;
        private readonly ITalentCompensationManager _talentCompensationManager;

        public TalentProfileCreationService(ISkillsManager skillsManager, 
            ITalentProfileManager talentProfileManager,
            ITalentCompensationManager talentCompensationManager)
        {
            _skillsManager = skillsManager;
            _talentProfileManager = talentProfileManager;
            _talentCompensationManager = talentCompensationManager;
        }
        public async Task<TalentProfileDto> TalentProfileCreation(AccountDto account, string firstname = "Max", string lastname = "Mustermann", string title = "Software Developer")
        {
            var skill = await _skillsManager.Get(account.id);
            var talentCompensation = await _talentCompensationManager.Add(new TalentCompensationDto
            {
                AccountId = account.id,
                Type = CompensationTypeEnum.Hourly,
                Wage = 80
            });

            //Save
            return await _talentProfileManager.Add(new TalentProfileDto
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
