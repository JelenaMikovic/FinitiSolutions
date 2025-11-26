using System.Data;
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
            Console.WriteLine("Middleware Start");
            if (context.User.Identity is ClaimsIdentity identity)
            {
                try
                {
                    User loggedUser = new User();

                    var idClaim = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    if (string.IsNullOrEmpty(idClaim))
                    {
                        throw new Exception("NameIdentifier claim is missing.");
                    }
                    loggedUser.Id = int.Parse(idClaim);
                    loggedUser.Email = identity.FindFirst(ClaimTypes.Email)?.Value;
                    loggedUser.Role = Enum.Parse<UserRole>(identity.FindFirst(ClaimTypes.Role)?.Value);

                    context.Items["loggedUser"] = loggedUser;
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
