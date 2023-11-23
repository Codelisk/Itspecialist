using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;
using Microsoft.EntityFrameworkCore;

namespace Itspecialist.Foundation.Dtos.Account
{
    [PrimaryKey(nameof(AccountId))]
    public partial class AccountSubBaseDto : BaseBaseIdDto
    {
        [Id]
        [Key]
        [ForeignKey(nameof(AccountDto))]
        public required Guid AccountId { get; set; }

        public override Guid GetId()
        {
            return AccountId;
        }
    }
}
