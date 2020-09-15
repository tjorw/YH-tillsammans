using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;

namespace tillsammans.Auth
{
    public static class HttpRequestExtensions
    {
        public static SessionDto GetSession(this HttpRequest req, ITokenService tokenService, string key)
        {
            var session = new SessionDto();

            try
            {
                session.UserId = getValue(req, "UserId");
                session.Expires = long.Parse(getValue(req, "Expires"));
                session.Token = getValue(req, "Token");
            } catch
            {

            }

            if(!tokenService.ValidateToken(session.Token, session, key))
            {
                throw new UnauthorizedAccessException();
            }

            return session;
        }

        private static string getValue(HttpRequest request, string key)
        {

            if (request.Query.ContainsKey(key))
            {
                return request.Query[key];
            }

            if (request.Headers.ContainsKey(key))
            {
                return request.Headers[key];
            }

            return null;
        }

        public static T DeserializeObject<T>(this HttpRequest req)
        {
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            return JsonConvert.DeserializeObject<T>(requestBody);
        }

    }
}
