using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itspecialist.Foundation.Dtos.Base
{
    public class BaseUserDtoWithName : BaseUserDto
    {
        public required string Name { get; set; }
    }
}
