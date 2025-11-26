using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using back.DTOs;
using back.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace back.Controllers
{
    [ApiController]
    [Route("api/term")]
    public class TermController : Controller
    {
        
        private readonly IUserService _userService;

        public TermController(IUserService userService)
        {
            _userService = userService;
        }

    }
}
