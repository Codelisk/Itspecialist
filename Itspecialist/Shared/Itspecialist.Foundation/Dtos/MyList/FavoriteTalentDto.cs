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
    public class FavoriteTalentDto : AccountReferenceBaseDto
    {
        [ForeignKey(nameof(TalentProfileDto))]
        public required Guid TalentProfileId { get; set; }
    }
}
