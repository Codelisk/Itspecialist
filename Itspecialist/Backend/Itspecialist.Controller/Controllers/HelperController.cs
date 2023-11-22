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
        private readonly IDistrictManager _districtManager;

        public HelperController(ItspecialistContext itspecialistContext,
            IProgrammingLanguageManager programmingLanguageManager,
            IProgrammingFrameworkManager programmingFrameworkManager,
            IDistrictManager districtManager)
        {
            _itspecialistContext = itspecialistContext;
            _programmingLanguageManager = programmingLanguageManager;
            _programmingFrameworkManager = programmingFrameworkManager;
            _districtManager = districtManager;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("Get")]
        public async Task AddMigrations()
        {
            _itspecialistContext.Database.Migrate();
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("SetupDb")]
        public async Task SetupDb()
        {
            //_itspecialistContext.Database.();

            var allLangs = await _programmingLanguageManager.GetAll();
            var allFrameworks = await _programmingFrameworkManager.GetAll();
            var allDistricts = await _districtManager.GetAll();

            foreach (var item in allLangs)
            {
                _programmingLanguageManager.Delete(item.id);
            }
            foreach (var item in allFrameworks)
            {
                _programmingFrameworkManager.Delete(item.id);
            }
            foreach (var item in allDistricts)
            {
                _districtManager.Delete(item.id);
            }

            _districtManager.Save(new DistrictDto { Name = "Gmunden" });
            _districtManager.Save(new DistrictDto { Name = "Vöcklabruck" });

            var csharp = await _programmingLanguageManager.Save(new ProgrammingLanguageDto { Name = "C#" });
            var java = await _programmingLanguageManager.Save(new ProgrammingLanguageDto { Name = "Java" });

            await _programmingFrameworkManager.Save(new ProgrammingFrameworkDto { Name = ".NET Core", ProgrammingLanguageId = csharp.id });
            await _programmingFrameworkManager.Save(new ProgrammingFrameworkDto { Name = ".NET MAUI", ProgrammingLanguageId = csharp.id });
            await _programmingFrameworkManager.Save(new ProgrammingFrameworkDto { Name = "Spring", ProgrammingLanguageId = java.id });
        }
    }
}
