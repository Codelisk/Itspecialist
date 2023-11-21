using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;

namespace Itspecialist.Foundation.Dtos.Account
{
    public partial class AccountSubBaseDto
    {
        [Id]
        [Key]
        [ForeignKey(nameof(AccountDto))]
        [JsonPropertyName("AccountId")]
        public required Guid AccountId { get; set; }
    }
}
