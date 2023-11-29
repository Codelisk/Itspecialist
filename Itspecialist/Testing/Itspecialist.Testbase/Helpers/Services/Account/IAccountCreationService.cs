using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itspecialist.Testbase.Helpers.Services.Account
{
    public interface IAccountCreationService
    {
        Task PostRegisterAccountSetup(AccountDto account, SkillsDto skill, List<ProgrammingFrameworkDto> primaryProgrammingFrameworks, List<ProgrammingFrameworkDto> secondaryProgrammingFrameworks = null);
        Task<AccountDto> RegisterNewAccount(string email);
    }
}
