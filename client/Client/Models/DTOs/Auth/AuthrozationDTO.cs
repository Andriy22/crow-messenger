using Application.Common.DTOs.Base;

namespace Application.Common.DTOs.Auth;

public record AuthorizationDTO(string Email,
    string Password,
    string? DeviceName, 
    string DeviceId, 
    string? DeviceType, 
    string? DeviceOS, 
    string? DeviceOSVersion, 
    string? DeviceAppVersion, 
    string? DeviceAppBuildNumber) : 
    BaseDeviceInfoDTO(DeviceName, DeviceId, DeviceType, DeviceOS, DeviceOSVersion, DeviceAppVersion, DeviceAppBuildNumber);