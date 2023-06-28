using FluentValidation;

namespace Application.Common.DTOs.Auth;

public class AuthorizationDTOValidator : AbstractValidator<AuthorizationDTO>
{
    public AuthorizationDTOValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(10);
    }
}