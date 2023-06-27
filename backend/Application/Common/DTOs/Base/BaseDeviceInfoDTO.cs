namespace Application.Common.DTOs.Base
{
    public abstract record BaseDeviceInfoDTO(string? DeviceName,
                                             string DeviceId,
                                             string? DeviceType,
                                             string? DeviceOS,
                                             string? DeviceOSVersion,
                                             string? DeviceAppVersion,
                                             string? DeviceAppBuildNumber);
}
