using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;
using Itspecialist.Foundation.Dtos.Base;
using Itspecialist.Foundation.Enums.Account;

namespace Itspecialist.Foundation.Dtos.Account
{
    [Dto]
    public class AccountCompensationDto : AccountSubBaseDto
    {
        public required decimal Wage { get; set; }
        public required CompensationTypeEnum Type { get; set; }
    }
}
