using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shopee.Data;
using Shopee.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shopee.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        ShopeeDBContext _context = new ShopeeDBContext();


        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                var userLogin = _context.Users.SingleOrDefault(
                u => u.Username == login.Username
                && u.Password == login.Password);

                if (userLogin == null)
                {
                    return Ok(new APIResponse
                    {
                        Success = false,
                        Msg = "Username or password in-correct!"
                    });
                }
                
                return Ok(new APIResponse
                    {
                        Success = true,
                        Msg = $"Login success, Username: {userLogin.Name}" +
                        $", Name: {userLogin.Name}"+
                        $", Email: {userLogin.Email}" +
                        $", Phone: {userLogin.Phone}"+
                        $", Role: {userLogin.Role}",
                        Data = $"Token = Null"
                });
                
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }

        }      
    }
}
