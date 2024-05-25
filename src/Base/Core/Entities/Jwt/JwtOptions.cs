namespace Core.Entities.Jwt
{
    public class JwtOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int TokenExpireTime { get; set; }
        public string Key { get; set; }
    }
}
