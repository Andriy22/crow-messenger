using System.Net;
using Application.Common.Constants;
using Application.Common.DTOs.Auth;
using Application.Common.Exceptions;
using Application.Common.ViewModels.Authorization;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace API.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IJWTService _jwtService;

    public AuthService(UserManager<AppUser> userManager, IJWTService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    public async Task<AuthorizationVM> AuthorizationAsync(AuthorizationDTO model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email) ??
                   throw new CustomHttpException("User not found!", HttpStatusCode.NotFound);
        var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);

        if (!isPasswordValid)
        {
            throw new CustomHttpException("Invalid password", HttpStatusCode.BadRequest);
        }

        return new AuthorizationVM
        {
            AccessToken = await _jwtService.GenerateSecurityTokenAsync(user),
            IsAccountConfirmed = user.EmailConfirmed,
            TokenType = AuthConstants.TokenType,
            UserId = user.Id
        };
    }
}