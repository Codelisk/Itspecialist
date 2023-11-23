using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;

namespace Itspecialist.Foundation.Dtos.MyList
{
    [Dto]
    [UserDto]
    public class FavoriteOpportunityDto : AccountReferenceBaseDto
    {
        [ForeignKey(nameof(CareerOpportunityDto))]
        public required Guid CareerOpportunityId { get; set; }
    }
}
