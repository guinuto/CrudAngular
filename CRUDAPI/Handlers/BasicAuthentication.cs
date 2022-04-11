using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Text;
using System.Net.Http.Headers;
using CRUDAPI.Models;
using System.Security.Claims;


namespace CRUDAPI.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>

    {

        private readonly DatabaseContext _context;
        public BasicAuthenticationHandler (
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,DatabaseContext ctx
        ) : base(options , logger , encoder ,clock)
        {
            _context = ctx;
        }
        protected override  async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Headers.ContainsKey("Authorization"))
               
            return AuthenticateResult.Fail("Authorization Header was not found ");

            
            var authenticationHeaderValue=AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            string[] credentials =Encoding.UTF8.GetString(bytes).Split(":");
            string name  = credentials[0];
            string password = credentials[1];
            Console.WriteLine(name);
            Console.WriteLine(password);
            if(name == "admin" && password == "123456")
            {
                var claims = new[] { new Claim(ClaimTypes.Name, name) };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                Console.WriteLine("Success!");
                return AuthenticateResult.Success(ticket);

            }

             
 



            return AuthenticateResult.Fail("Precisa ser implementado");
        }
    }
}