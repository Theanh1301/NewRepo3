using Microsoft.IdentityModel.Tokens;
using Shopee.Data;
using Shopee.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shopee.Responsitories
{
    public class AccountRespository : IAccountResponsitory
    {
        ShopeeDBContext _context = new ShopeeDBContext();
        private readonly IConfiguration _configuration;

        public AccountRespository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> SignInAsync(UserModel userData)
        {
            var result = _context.Users
                .Where(u => u.Username == userData.Username 
                && u.Password == userData.Password).FirstOrDefault();
            if (result == null)
                return string.Empty;
            else
                return GetToken(userData);           
        }
        public string GetToken(UserModel userData)
        {
            var user = _context.Users
                .Where(u => u.Username == userData.Username
                && u.Password == userData.Password).FirstOrDefault();
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWT:Subject"]),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(ClaimTypes.Role, user.Role.ToString()),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.MobilePhone, user.Phone.ToString()),
                 new Claim(ClaimTypes.Name, user.Name),
                 new Claim("Username", userData.Username),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["JWT:Issuer"],
                _configuration["JWT:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signIn);

            string Token = new JwtSecurityTokenHandler().WriteToken(token);
            return Token;
        }
    }
}
