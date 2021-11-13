namespace BugLab.Business.Options
{
    public class JwtOptions
    {
        public string TokenKey { get; init; }
        public string ValidIssuer { get; init; }
        public string ValidAudience { get; init; }
    }
}
