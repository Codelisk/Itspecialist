using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;
using Itspecialist.Foundation.Dtos.Skills;
using Itspecialist.Foundation.Enums.Account;

namespace Itspecialist.Foundation.Dtos.Opportunity
{
    [Dto]
    [UserDto]
    [CustomizeGetAll(AllowAnonymous = true)]
    public class CareerOpportunityDto : Base.BaseUserDto
    {
        [ForeignKey(nameof(DistrictDto))]
        public required Guid DistrictId { get; set; }
        [ForeignKey(nameof(SkillsDto))]
        public required Guid SkillsId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required Guid CompanyId { get; set; }
        public required PreferredEmploymentStatusEnum PreferredEmploymentStatus { get; set; }
        public required DateTime CreatedDate { get; set; }
    }
}
