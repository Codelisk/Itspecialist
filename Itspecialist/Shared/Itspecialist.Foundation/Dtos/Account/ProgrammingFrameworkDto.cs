using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes;

namespace Itspecialist.Foundation.Dtos.Account
{
    [Dto]
    public class ProgrammingFrameworkDto : Base.BaseDtoWithName
    {
        [ForeignKey(nameof(ProgrammingLanguageDto))]
        public required Guid ProgrammingLanguageId { get; set; }
    }
}
