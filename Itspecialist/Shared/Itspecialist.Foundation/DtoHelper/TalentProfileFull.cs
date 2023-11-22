using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itspecialist.Foundation.DtoHelper
{
    public record TalentProfileFull3(TalentProfileDto TalentProfile, TalentCompensationDto? TalentCompensation, DistrictDto District);
}
