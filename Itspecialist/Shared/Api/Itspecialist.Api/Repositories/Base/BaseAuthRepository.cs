using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itspecialist.Api.Repositories.Base
{
    [Codelisk.GeneratorAttributes.ApiAttributes.DefaultApiRepository]
    public class BaseAuthRepository<TApi> : BaseRepository<TApi> where TApi : IBaseApi
    {
        public BaseAuthRepository(IBaseRepositoryProvider baseRepositoryProvider) : base(baseRepositoryProvider)
        {
        }
    }
}
