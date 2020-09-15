namespace tillsammans.Auth
{
    public interface ITokenService
    {
        string CreateToken(string values, string key, string salt);
        bool ValidateToken(string token, string values, string key, string salt);
    }
}