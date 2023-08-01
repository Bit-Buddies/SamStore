namespace SamStore.WebAPI.Core.Identity
{
    public class IdentitySettingsDTO
    {
        public string Secret { get; set; }
        public int HoursToExpire { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
