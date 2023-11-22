using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itspecialist.Foundation.Dtos.Account
{
    public class AccountReferenceBaseDto : BaseDefaultIdDto
    {
        [ForeignKey(nameof(AccountDto))]
        public required Guid AccountId { get; set; }
    }
}
