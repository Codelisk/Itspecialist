using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Foundation.Enums.Account;

namespace ModuleAccount.Contracts.Services.AccountSetup
{
    public interface IAccountSetupProvider
    {
        DistrictDto? District { get; set; }
        AccountTypeEnum? AccountType { get; set; }
        SkillsDto? Skill { get; set; }
        List<ProgrammingFrameworkDto>? PrimaryFrameworks { get; set; }
        List<ProgrammingFrameworkDto>? SecondaryFrameworks { get; set; }
    }
}
