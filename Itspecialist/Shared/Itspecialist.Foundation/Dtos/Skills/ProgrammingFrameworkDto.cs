using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;

namespace Itspecialist.Foundation.Dtos.Skills
{
    [Dto]
    [CustomizeGetAll(AllowAnonymous = true)]
    public class ProgrammingFrameworkDto : BaseDtoWithName
    {
        [ForeignKey(nameof(ProgrammingLanguageDto))]
        public required Guid ProgrammingLanguageId { get; set; }
    }
}
