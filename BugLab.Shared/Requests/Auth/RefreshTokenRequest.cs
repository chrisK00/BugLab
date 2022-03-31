using System.ComponentModel.DataAnnotations;

namespace BugLab.Shared.Requests.Auth
{
    public class RefreshTokenRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string RefreshToken { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string AccessToken { get; set; }
    }
}
