using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServerHost.Quickstart.UI;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class ProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //>Processing
            var sub = context.Subject.GetSubjectId();

            var user = TestUsers.Users.First(u => u.SubjectId == sub);

            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.GivenName, user.Username),
            };

            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }
}
