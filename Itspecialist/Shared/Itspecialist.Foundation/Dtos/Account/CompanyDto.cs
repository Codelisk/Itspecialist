using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itspecialist.Foundation.Dtos.Account
{
    [Dto]
    public class CompanyDto : AccountReferenceBaseDto
    {
        public string Name { get; set; }
    }
}
