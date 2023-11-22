using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;
using Codelisk.GeneratorAttributes;
using Itspecialist.Foundation.Dtos.Account;
using Itspecialist.Foundation.Dtos.Base;
using Itspecialist.Foundation.Enums.Account;

namespace Itspecialist.Foundation.Dtos.Talent
{
    [Dto]
    [CustomizeGetAll(AllowAnonymous = true)]
    public class TalentCompensationDto : AccountReferenceBaseDto
    {
        public required decimal Wage { get; set; }
        public required CompensationTypeEnum Type { get; set; }
    }
}
