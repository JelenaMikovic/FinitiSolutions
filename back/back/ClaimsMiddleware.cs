using System.Security.Claims;

namespace back
{
    public class ClaimsMiddleware
    {
        private readonly RequestDelegate _next;

        public ClaimsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.User.Identity is ClaimsIdentity identity && context.User.Identity.IsAuthenticated)
            {
                try
                {
                    User loggedUser = new User();

                    var idClaim = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
                    if (string.IsNullOrEmpty(idClaim))
                    {
                        Console.WriteLine("Warning: User ID claim is missing.");
                    }
                    else
                    {
                        loggedUser.Id = int.Parse(idClaim);
                    }

                    var emailClaim = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
                    if (!string.IsNullOrEmpty(emailClaim))
                    {
                        loggedUser.Email = emailClaim;
                    }

                    var roleClaim = identity.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
                    if (!string.IsNullOrEmpty(roleClaim))
                    {
                        loggedUser.Role = Enum.Parse<UserRole>(roleClaim);
                    }

                    if (loggedUser.Id > 0)
                    {
                        context.Items["loggedUser"] = loggedUser;
                        //Console.WriteLine($"Logged user: {loggedUser.Email} ({loggedUser.Role})");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception in middleware: {ex}");
                }
            }

            await _next(context);
        }
    }
}
