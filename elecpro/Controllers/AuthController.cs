using elecpro.Dtos;
using elecpro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace elecpro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _contextAccessor;
        public AuthController(IAuthService authService, IHttpContextAccessor contextAccessor)
        {
            _authService = authService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterAsync(model);
               _contextAccessor.HttpContext.Response.Cookies.Append("token", result.Token, new CookieOptions { HttpOnly = true });
                if (result.IsAuthenticated)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("Token")]
        public async Task<IActionResult> GetToken(TokenRequestDto model)
        {
            var result = await _authService.GetTokenAsync(model);
            _contextAccessor.HttpContext.Response.Cookies.Append("token", result.Token, new CookieOptions { HttpOnly = true });
            if (result.IsAuthenticated)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
            return BadRequest(result);
        }
    }
}
