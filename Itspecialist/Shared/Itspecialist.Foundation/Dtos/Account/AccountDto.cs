using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;
using Codelisk.GeneratorAttributes;
using Itspecialist.Foundation.Enums.Account;

namespace Itspecialist.Foundation.Dtos.Account
{
    [Dto]
    [UserDto]
    public class AccountDto : Base.BaseUserDtoWithName
    {
        public required string Email { get; set; }
        public required Guid PrimaryProgrammingLanguage { get; set; }
        public Guid? SecondaryProgrammingLanguage { get; set; }
        public required PreferredEmploymentStatusEnum PreferredEmploymentStatus { get; set; }
    }
}
