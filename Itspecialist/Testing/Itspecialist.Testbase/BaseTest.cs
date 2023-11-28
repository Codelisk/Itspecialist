using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itspecialist.Testbase.Helpers.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Itspecialist.Testbase
{
    public class BaseTest
    {
        private IServiceProvider ServiceProvider { get; set; }
        public BaseTest() 
        {
            ServiceProvider = Helper.Provider();
        }

        public T GetRequiredService<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }
    }
}
