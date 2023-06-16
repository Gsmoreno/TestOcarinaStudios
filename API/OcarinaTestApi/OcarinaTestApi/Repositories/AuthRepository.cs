using Microsoft.IdentityModel.Tokens;
using OcarinaTestApi.Contexts;
using OcarinaTestApi.Domains;
using OcarinaTestApi.Inteface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OcarinaTestApi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        GufiContext ctx = new GufiContext();

        private readonly IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<string> Login(string email, string password)
        {
            try
            {
                var dbSearch = ctx.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();

                if (dbSearch == null)
                {
                    return Task.FromResult(string.Empty);
                }

                var token = CreateToken(dbSearch);

                return Task.FromResult(token);
            }
            catch (Exception ex)
            {
                return Task.FromResult(ex.ToString());
            }
        }

        private string CreateToken(User usuario)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenKey").Value);

            var tipoUsuario = "1";

           

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, tipoUsuario)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                IssuedAt = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private void CreatePasswordHash(string password)
        {
            SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(password);
        }
    }
}
