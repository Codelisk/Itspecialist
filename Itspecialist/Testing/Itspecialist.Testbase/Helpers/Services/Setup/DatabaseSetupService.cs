using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Managers;

namespace Itspecialist.Testbase.Helpers.Services.Setup
{
    internal class DatabaseSetupService : IDatabaseSetupService
    {
        public IDistrictManager _districtManager;
        public IProgrammingFrameworkManager _programmingFrameworkManager;
        public IProgrammingLanguageManager _programmingLanguageManager;
        public DatabaseSetupService(IDistrictManager districtManager, 
            IProgrammingFrameworkManager programmingFrameworkManager,
            IProgrammingLanguageManager programmingLanguageManager)
        {
            _districtManager = districtManager;
            _programmingFrameworkManager = programmingFrameworkManager;
            _programmingLanguageManager = programmingLanguageManager;
        }
        public async Task SetupDefaultDatabaseTables(string[]? districtNames = default, string[]? programmingLanguageNames = default)
        {
            if(districtNames is null)
            {
                districtNames = ["Gmunden"];
            }
            if(programmingLanguageNames is null)
            {
                programmingLanguageNames = ["C#", "Java"];
            }

            await _districtManager.AddRange(districtNames.Select(x=>new DistrictDto { Name = x}).ToList());

            await _programmingLanguageManager.AddRange(programmingLanguageNames.Select(x => new ProgrammingLanguageDto { Name = x }).ToList());

            var programmingLanguages = await _programmingLanguageManager.GetAll();

            await _programmingFrameworkManager.Add(
                new ProgrammingFrameworkDto { ProgrammingLanguageId = programmingLanguages.First().id, Name = ".NET Core" }
                );
            await _programmingFrameworkManager.Add(
                new ProgrammingFrameworkDto { ProgrammingLanguageId = programmingLanguages.First().id, Name = ".NET MAUI" }
                );
        }

    }
}
