using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes;
using Codelisk.GeneratorAttributes.WebAttributes.Dto;

namespace Itspecialist.Foundation.Dtos.Account
{
    [Dto]
    [CustomizeGetAll(AllowAnonymous = true)]
    public class DistrictDto : Base.BaseDtoWithName
    {
    }
}
