using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Itspecialist.Api.Services.Base
{
    public interface IBaseRepositoryProvider
    {
        IApiBuilder GetApiBuilder();
        IAuthenticationService GetAuthenticationService();
        ILogger GetLogger();
        ITokenProvider GetTokenProvider();
    }
}
