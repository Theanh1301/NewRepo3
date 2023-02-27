using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopee.Models;

namespace Shopee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ShopeeDBContext context = new ShopeeDBContext();
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var user = context.Users.SingleOrDefault(
                u => u.Username == username
                && u.Password == password);

                if (user == null)
                {
                    return NotFound("Your username or password are wrong! Please check your information!");
                }

                if (user.Role == 1)
                {
                    return Ok(user.Role);
                }
                else if (user.Role == 2)
                {
                    return Ok(user.Role);
                }
                else
                {
                    return Ok(user.Role);

                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
