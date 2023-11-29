using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itspecialist.Foundation.Helper
{
    public static class DateTimeHelper
    {
        public static DateTime Now()
        {
            return DateTime.UtcNow;
        }
    }
}
