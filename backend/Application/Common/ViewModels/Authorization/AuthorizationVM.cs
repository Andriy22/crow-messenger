using Newtonsoft.Json;

namespace Application.Common.ViewModels.Authorization
{
    public record AuthorizationVM
    {
        [JsonProperty("is_account_confirmed")] public required bool IsAccountConfirmed { get; init; }
        [JsonProperty("access_token")] public required string AccessToken { get; init; }
        [JsonProperty("user_id")] public required string UserId { get; init; }
        [JsonProperty("token_type")] public required string TokenType { get; init; }
    }
}
