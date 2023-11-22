using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;
using Codelisk.GeneratorAttributes;
using Itspecialist.Foundation.Enums.Account;
using System.ComponentModel.DataAnnotations.Schema;
using Itspecialist.Foundation.Dtos.Skills;

namespace Itspecialist.Foundation.Dtos.Account
{
    [Dto]
    [UserDto]
    public class AccountDto : Base.BaseUserDtoWithName
    {
        public required string Email { get; set; }
        public required AccountTypeEnum AccountType { get; set; }
        [ForeignKey(nameof(DistrictDto))]
        public required Guid DistrictId { get; set; }
    }
}
