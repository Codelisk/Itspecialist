using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;

namespace Itspecialist.Foundation.Dtos.Base
{
    public abstract class BaseBaseIdDto
    {
        [GetId]
        public abstract Guid GetId();
    }
}
