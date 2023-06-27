using Application.Common.DTOs.Base;

namespace Application.Common.DTOs.Registration
{
    public record RegistrationDTO : BaseDeviceInfoDTO
    {
        public string NickName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string ConfirmPassword { get; init; }

        public RegistrationDTO(string? deviceName,
            string deviceId,
            string? deviceType,
            string? deviceOS,
            string? deviceOSVersion,
            string? deviceAppVersion,
            string? deviceAppBuildNumber,
            string nickName,
            string email,
            string password,
            string confirmPassword) :
            base(deviceName, deviceId, deviceType, deviceOS, deviceOSVersion, deviceAppVersion, deviceAppBuildNumber)
        {
            NickName = nickName;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}