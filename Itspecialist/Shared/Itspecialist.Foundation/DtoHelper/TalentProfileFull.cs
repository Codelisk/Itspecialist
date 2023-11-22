using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itspecialist.Foundation.DtoHelper
{
    public record TalentProfileFull(TalentProfileDto TalentProfile, TalentCompensationDto? TalentCompensation, DistrictDto District);
}
