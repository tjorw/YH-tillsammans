using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;

namespace tillsammans.Auth
{

    public static class ITokenServiceExtenstions
    {
        public static string CreateToken(this ITokenService tokenService, SessionDto session, string key)
        {
            var value = getValue(session);

            return tokenService.CreateToken(value, key, "");
        }
        public static bool ValidateToken(this ITokenService tokenService, string token, SessionDto session, string key)
        {
            var value = getValue(session);

            return tokenService.ValidateToken(token, value, key, "");
        }

        private static string getValue(SessionDto session)
        {
            return $"<{ session.UserId }><{session.Expires:yyyy-MM-dd hh:mm:ss}>";
        }

    }


}
