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
    }
}
