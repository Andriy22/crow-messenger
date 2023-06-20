using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("authorize")]
        public IActionResult Authorization(AuthorizationDTO model)
        {
            return Ok(model);
        }
    }
}
