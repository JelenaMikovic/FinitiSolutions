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
        
        private readonly ITermService _termService;

        public TermController(ITermService termService)
        {
            _termService = termService;
        }

        [HttpGet("published")]
        public async Task<IActionResult> GetPublishedTerms()
        {
            try
            {
                var terms = await _termService.GetPublishedTerms();
                return Ok(terms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("draft")]
        public async Task<IActionResult> GetDraftTerms()
        {
            try
            {
                if (HttpContext.Items["loggedUser"] is not User loggedUser || loggedUser.Role != UserRole.ADMIN)
                {
                    return Unauthorized("Only authors can access draft terms.");
                }
                var terms = await _termService.GetDraftTerms(loggedUser.Id);
                return Ok(terms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("archived")]
        public async Task<IActionResult> GetArchivedTerms()
        {
            try
            {
                if (HttpContext.Items["loggedUser"] is not User loggedUser || loggedUser.Role != UserRole.ADMIN)
                {
                    return Unauthorized("Only authors can access archived terms.");
                }
                var terms = await _termService.GetArchivedTerms();
                return Ok(terms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
