using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace BugLab.Blazor.Helpers
{
    public static class TokenHelper
    {
        public static IEnumerable<Claim> ParseClaims(string token)
        {
            var payload = token.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var claimValues = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return claimValues.Select(cv => new Claim(cv.Key, cv.Value.ToString()));
        }

        public static bool HasExpired(this IEnumerable<Claim> claims)
        {
            var expirationClaim = claims.First(x => x.Type == "exp");
            var expirationDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expirationClaim.Value));

            return expirationDate.UtcDateTime <= DateTime.UtcNow;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            return Convert.FromBase64String(base64);
        }
    }
}
