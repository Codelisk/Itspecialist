using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;

namespace Itspecialist.Foundation.Dtos.Skills
{
    [Dto]
    public class SkillsDto : AccountSubBaseDto
    {
        [ForeignKey(nameof(ProgrammingLanguageDto))]
        public required Guid PrimaryProgrammingLanguage { get; set; }
        [ForeignKey(nameof(ProgrammingLanguageDto))]
        public Guid? SecondaryProgrammingLanguage { get; set; }
    }
}
