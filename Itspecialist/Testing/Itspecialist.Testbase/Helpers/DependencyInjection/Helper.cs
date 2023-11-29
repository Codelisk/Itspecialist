using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Itspecialist.Server;
using Itspecialist.Database;
using Microsoft.EntityFrameworkCore;
using ModuleAccount.Contracts;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using System.Net.Http;
using Itspecialist.Testbase.Mocks;
using Itspecialist.Testbase.Helpers.Services.Account;
using Itspecialist.Testbase.Helpers.Services.Talent;
using Itspecialist.Testbase.Helpers.Services.Opportunity;

namespace Itspecialist.Testbase.Helpers.DependencyInjection
{
    public static class Helper
    {
        public static IServiceProvider Provider()
        {
            var services = new ServiceCollection();

            services.AddScoped<IHttpContextAccessor, TestHttpContext>();

            services.AddDbContext<ItspecialistContext>(o => o.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            services.AddAutoMapper();
            services.AddAllServices();

            //Uno
            services.AddModuleAccountContracts();

            //Testing specific services
            services.AddSingleton<IAccountCreationService, AccountCreationService>();
            services.AddSingleton<ITalentProfileCreationService, TalentProfileCreationService>();
            services.AddSingleton<IOpportunityProfileCreationService, OpportunityProfileCreationService>();

            return services.BuildServiceProvider();
        }
    }
}
