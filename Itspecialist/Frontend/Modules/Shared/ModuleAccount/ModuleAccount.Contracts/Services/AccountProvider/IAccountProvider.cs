using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleAccount.Contracts.Services.AccountProvider
{
    public interface IAccountProvider
    {
        AccountDto? Account { get; }

        Task<bool> SetAccountAsync();
    }
}
