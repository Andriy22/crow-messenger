using Application.Common.Constants;
using Application.Common.DTOs.Registration;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Text;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId) ?? throw new CustomHttpException("User not found", HttpStatusCode.NotFound);

            var decodedCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

            var result = await _userManager.ConfirmEmailAsync(user, decodedCode);

            if (!result.Succeeded)
            {
                throw IdentityHelper.GetIdentityErrors(result);
            }
        }

        public async Task<string> GenerateEmailConfirmationLinkAsync(AppUser user, string callbackUrl)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            return $"{callbackUrl}?userId={user.Id}&token={encodedToken}";
        }

        public async Task<AppUser> RegisterAsync(RegistrationDTO model)
        {
            var (NickName, Email, Password) = (model.NickName, model.Email, model.Password);

            var user = new AppUser
            {
                Nickname = NickName,
                Email = Email,
                UserName = Email,
                LastLoginDate = DateTime.UtcNow,
                RegistrationDate = DateTime.UtcNow,
                Bio = string.Empty,
            };

            var result = await _userManager.CreateAsync(user, Password);

            if (!result.Succeeded)
            {
                throw IdentityHelper.GetIdentityErrors(result);
            }

            result = await _userManager.AddToRoleAsync(user, UserRoleConstants.UserRole);

            if (!result.Succeeded)
            {
                throw IdentityHelper.GetIdentityErrors(result);
            }

            return user;
        }
    }
}
