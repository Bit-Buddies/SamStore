namespace SamStore.WebAPI.Core.Identity
{
    public class IdentitySettings
    {
        public string Secret { get; set; }
        public int HoursToExpire { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
