using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Itspecialist.Testbase.Mocks
{
    public class TestHttpContext : IHttpContextAccessor
    {
        public static Guid UserId = Guid.NewGuid();
        public TestHttpContext()
        {
            SetupHttpContext();
        }
        public void SetupHttpContext(Guid? UserId = null)
        {
            if (UserId is null)
            {
                UserId = Guid.NewGuid();
            }

            HttpContext = new DefaultHttpContext();
            HttpContext.User = new ClaimsPrincipal(new List<ClaimsIdentity>
            {
                new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, UserId!.ToString())
                })
            });
        }
        public HttpContext? HttpContext { get; set; }
    }
}
