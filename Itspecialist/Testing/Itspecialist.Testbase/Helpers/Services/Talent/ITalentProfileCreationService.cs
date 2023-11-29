using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itspecialist.Testbase.Helpers.Services.Talent
{
    public interface ITalentProfileCreationService
    {
        Task<TalentProfileDto> TalentProfileCreation(AccountDto account, string firstname = "Max", string lastname = "Mustermann", string title = "Software Developer");
    }
}
