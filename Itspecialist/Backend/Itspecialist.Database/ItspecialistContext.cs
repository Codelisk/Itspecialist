using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Itspecialist.Foundation.Dtos.User;
using Codelisk.GeneratorAttributes.WebAttributes.Database;
using Microsoft.EntityFrameworkCore;

namespace Itspecialist.Database
{
    [Codelisk.GeneratorAttributes.WebAttributes.Database.BaseContext]
    public partial class ItspecialistContext : IdentityDbContext<UserDto, IdentityRole<Guid>, Guid>
    {
        public ItspecialistContext(DbContextOptions options) : base(options)
        {
        }
    }
}
