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

        public HelperController(ItspecialistContext itspecialistContext)
        {
            _itspecialistContext = itspecialistContext;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("Get")]
        public async Task AddMigrations()
        {
            _itspecialistContext.Database.Migrate();
        }
    }
}
