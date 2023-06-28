using Application.Common.DTOs.Auth;
using Application.Common.ViewModels.Authorization;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<AuthorizationVM> AuthorizationAsync(AuthorizationDTO model);
}