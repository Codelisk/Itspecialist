using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;
using Itspecialist.Foundation.Dtos.Account;
using Itspecialist.Foundation.Dtos.Base;

namespace Itspecialist.Foundation.Dtos.Talent
{
    [Dto]
    [UserDto]
    public class TalentProfileDto : BaseUserDto
    {
        public required string Title { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [ForeignKey(nameof(AccountDto))]
        public required Guid AccountId { get; set; }
        [ForeignKey(nameof(TalentCompensationDto))]
        public Guid? TalentCompensationId { get; set; }
    }
}
