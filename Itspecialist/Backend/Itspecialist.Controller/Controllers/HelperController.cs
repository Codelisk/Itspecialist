using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Database;
using Microsoft.EntityFrameworkCore;

namespace Itspecialist.Controller.Controllers
{
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class HelperController
    {
        private readonly ItspecialistContext _itspecialistContext;
        private readonly IProgrammingLanguageManager _programmingLanguageManager;
        private readonly IProgrammingFrameworkManager _programmingFrameworkManager;

        public HelperController(ItspecialistContext itspecialistContext,
            IProgrammingLanguageManager programmingLanguageManager,
            IProgrammingFrameworkManager programmingFrameworkManager)
        {
            _itspecialistContext = itspecialistContext;
            _programmingLanguageManager = programmingLanguageManager;
            _programmingFrameworkManager = programmingFrameworkManager;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("Get")]
        public async Task AddMigrations()
        {
            _itspecialistContext.Database.Migrate();
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("ClearDb")]
        public async Task ClearDb()
        {
            _itspecialistContext.Database.();

            var csharp = await _programmingLanguageManager.Save(new ProgrammingLanguageDto { Name = "C#" });
            var java = await _programmingLanguageManager.Save(new ProgrammingLanguageDto { Name = "Java" });

            await _programmingFrameworkManager.Save(new ProgrammingFrameworkDto { Name = ".NET Core", ProgrammingLanguageId = csharp.id });
            await _programmingFrameworkManager.Save(new ProgrammingFrameworkDto { Name = ".NET MAUI", ProgrammingLanguageId = csharp.id });
            await _programmingFrameworkManager.Save(new ProgrammingFrameworkDto { Name = "Spring", ProgrammingLanguageId = java.id });
        }
    }
}
