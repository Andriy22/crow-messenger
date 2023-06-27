using Application.Common.DTOs.Registration;
using Domain;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<AppUser> RegisterAsync(RegistrationDTO model);
        Task<string> GenerateEmailConfirmationLinkAsync(AppUser user, string callbackUrl);
        Task ConfirmEmailAsync(string userId, string token);
    }
}
