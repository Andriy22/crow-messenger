using Domain;

namespace Application.Interfaces
{
    public interface IJWTService
    {
        Task<string> GenerateSecurityTokenAsync(AppUser user);
    }
}
