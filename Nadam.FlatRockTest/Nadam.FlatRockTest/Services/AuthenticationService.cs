using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

using Nadam.FlatRockTest.Models;

namespace Nadam.FlatRockTest.Services
{
    public class AuthenticationService : AuthenticationHandler<User>
    {
        public AuthenticationService(
            IOptionsMonitor<User> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
