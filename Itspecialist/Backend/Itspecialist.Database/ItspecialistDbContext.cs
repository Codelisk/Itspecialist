using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Itspecialist.Foundation.Dtos.User;

namespace Itspecialist.Database
{
    public class ItspecialistDbContext : IdentityDbContext<UserDto, IdentityRole<Guid>, Guid>
    {
    }
}
