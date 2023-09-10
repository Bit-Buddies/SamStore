namespace SamStore.Authentication.API.Models
{
    public record UserDataDTO
    {
        public string AccessToken { get; set; }
        public double HoursToExpire { get; set; }
        public UserToken UserToken { get; set; }
    }

    public record UserToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }

    public record UserClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
