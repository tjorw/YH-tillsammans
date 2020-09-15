using System;

namespace tillsammans.Auth
{
    public class TokenService : ITokenService
    {
        public string CreateToken(string values, string key, string salt)
        {
            var hash = GetStringSha256Hash($"{key}{salt}{values}");

            return hash;
        }

        public bool ValidateToken(string token, string values, string key, string salt)
        {
            var hash = GetStringSha256Hash($"{key}{salt}{values}");

            return (token == hash);
        }

        internal static string GetStringSha256Hash(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

    }

}
