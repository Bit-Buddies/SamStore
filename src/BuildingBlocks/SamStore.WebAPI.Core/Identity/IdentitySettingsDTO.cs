namespace SamStore.WebAPI.Core.Identity
{
    public record IdentitySettingsDTO(string Secret, int HoursToExpire, string Issuer, string Audience);
}
