using Azure;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace QuanLyPhanTuWeb.Helper
{
    public  static class TokenHelper
    {
        public static string GetRoleFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);
            var expiration = token.ValidTo;
            if (DateTime.UtcNow <= expiration)
            {
                var roleClaim = token.Claims.FirstOrDefault(c => c.Type == "role");
                if (roleClaim != null)
                {
                    return roleClaim.Value;
                }
            }
            return null;
        }

        public static int GetIdFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (!string.IsNullOrEmpty(jwtToken))
            {
                var token = tokenHandler.ReadJwtToken(jwtToken);
                var expiration = token.ValidTo;
                if (DateTime.UtcNow <= expiration)
                {
                    var idClaim = token.Claims.FirstOrDefault(c => c.Type == "accountId");
                    int Id;
                    if (int.TryParse(idClaim.Value, out Id))
                    {
                        return Id;
                    }
                }
            }
            return -1;

        }
    }
}
