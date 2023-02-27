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
                    return NotFound();
                }

                if (user.Role == 1)
                {
                    
                }
                else if (user.Role == 2)
                {

                }
                else
                {

                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
