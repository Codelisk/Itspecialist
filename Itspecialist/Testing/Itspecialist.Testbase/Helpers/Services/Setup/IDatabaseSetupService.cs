using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itspecialist.Testbase.Helpers.Services.Setup
{
    public interface IDatabaseSetupService
    {
        Task SetupDefaultDatabaseTables(string[]? districtNames = null, string[]? programmingLanguageNames = null);
    }
}
