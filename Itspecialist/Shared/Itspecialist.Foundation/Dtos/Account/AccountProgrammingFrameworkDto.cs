using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;
using Codelisk.GeneratorAttributes;

namespace Itspecialist.Foundation.Dtos.Account
{
    [Dto]
    [UserDto]
    public class AccountProgrammingFrameworkDto
    {
        [ForeignKey(nameof(AccountDto))]
        public required Guid AccountId { get; set; }

        [ForeignKey(nameof(ProgrammingFrameworkDto))]
        public required Guid ProgrammingFrameworkId { get; set; }
    }
}
