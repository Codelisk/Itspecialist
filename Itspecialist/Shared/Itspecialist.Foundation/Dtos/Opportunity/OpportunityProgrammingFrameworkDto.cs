using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;

namespace Itspecialist.Foundation.Dtos.Opportunity
{
    [Dto]
    [CustomizeGetAll(AllowAnonymous = true)]
    public class OpportunityProgrammingFrameworkDto : BaseDefaultIdDto
    {
        [ForeignKey(nameof(CareerOpportunityDto))]
        public required Guid CareerOpportunityId { get; set; }

        [ForeignKey(nameof(ProgrammingFrameworkDto))]
        public required Guid ProgrammingFrameworkId { get; set; }
    }
}
