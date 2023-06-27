using FluentValidation;

namespace Application.Common.DTOs.Registration
{
    public class RegistrationDTOValidator : AbstractValidator<RegistrationDTO>
    {
        public RegistrationDTOValidator()
        {
            RuleFor(x => x.NickName).NotEmpty().WithMessage("Nickname is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(10).WithMessage("Minimum length of password is 10");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password is required").Equal(x => x.Password).WithMessage("Confirm password must equals password");
            RuleFor(x => x.DeviceId).NotEmpty().WithMessage("Device Id is required");
        }
    }
}