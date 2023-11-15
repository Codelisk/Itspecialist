using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.ApiAttributes;

namespace Itspecialist.Api.Apis.Base
{
    [BaseApi]
    [Headers("Authorization:Bearer")]
    public interface IBaseApi
    {
    }
}
