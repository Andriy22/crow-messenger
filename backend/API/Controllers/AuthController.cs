using Application.Common.DTOs.Auth;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("authorize")]
        public async Task<IActionResult> Authorization(AuthorizationDTO model)
        {
            return Ok(await _authService.AuthorizationAsync(model));
        }
    }
}
