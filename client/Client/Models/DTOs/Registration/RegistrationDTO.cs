using Application.Common.DTOs.Base;

namespace Application.Common.DTOs.Registration
{
    public record RegistrationDTO(string NickName,
        string Email,
        string Password,
        string? DeviceName,
        string DeviceId, 
        string? DeviceType, 
        string? DeviceOS,
        string? DeviceOSVersion, 
        string? DeviceAppVersion, 
        string? DeviceAppBuildNumber) : 
        BaseDeviceInfoDTO(DeviceName, DeviceId, DeviceType, DeviceOS, DeviceOSVersion, DeviceAppVersion, DeviceAppBuildNumber);
}