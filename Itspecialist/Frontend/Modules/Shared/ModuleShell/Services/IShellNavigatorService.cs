using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleShell.Contracts.Services
{
    public interface IShellNavigatorService
    {
        Task NavigateToJobsAsync<TNavigator>(TNavigator navigator);
    }
}
