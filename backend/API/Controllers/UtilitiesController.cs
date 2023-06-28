using Application.User.Queries.GetUserByNicknameQuery;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class UtilitiesController : BaseController
{
    private readonly UserManager<AppUser> _userManager;

    public UtilitiesController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("check-nickname-availability")]
    public async Task<IActionResult> CheckNicknameAvailabilityAsync(string nickname)
    {
        var user = await Mediator.Send(new GetUserByNicknameQuery(nickname));

        return Ok(user == null);
    }
    
    [HttpGet("check-email-availability")]
    public async Task<IActionResult> CheckEmailAvailabilityAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        return Ok(user == null);
    }
}