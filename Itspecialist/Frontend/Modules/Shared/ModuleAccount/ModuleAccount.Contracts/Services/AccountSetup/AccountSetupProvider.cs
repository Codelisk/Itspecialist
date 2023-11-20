using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Foundation.Enums.Account;
using ModuleAccount.Contracts.Services.AccountProvider;

namespace ModuleAccount.Contracts.Services.AccountSetup
{
    internal class AccountSetupProvider : IAccountSetupProvider
    {
        public DistrictDto? District { get; set; }
        public AccountTypeEnum? AccountType { get; set; }
        public SkillsDto? Skill { get; set; }
        public List<ProgrammingFrameworkDto>? PrimaryFrameworks { get; set; }
        public List<ProgrammingFrameworkDto>? SecondaryFrameworks { get; set; }
    }
}
