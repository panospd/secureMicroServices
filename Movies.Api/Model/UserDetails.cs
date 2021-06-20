using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Movies.Api.Model
{
    public class UserDetails
    {
        public string GivenName { get; }

        public UserDetails(IHttpContextAccessor httpContextAccessor)
        {
            var givenName = httpContextAccessor.HttpContext.User
                .Claims
                .First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")
                .Value;

            GivenName = givenName;
        }
    }
}
