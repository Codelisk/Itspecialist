using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itspecialist.Foundation.DtoHelper
{
    public record AccountFull(AccountDto Account,
        ProgrammingLanguageDto PrimaryProgrammingLanguage, 
        ProgrammingLanguageDto? SecondaryProgrammingLanguage, 
        List<ProgrammingFrameworkDto> PrimaryFameworks,
        List<ProgrammingFrameworkDto>? SecondaryFameworks)
    {
    }
}
