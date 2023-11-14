namespace Itspecialist.Api.Models.Auth
{
    public class AuthResult
    {
        public required string tokenType { get; set; }
        public required string accessToken { get; set; }
        public required int expiresIn { get; set; }
        public required string refreshToken { get; set; }
    }
}
