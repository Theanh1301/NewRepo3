using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopee.Models;

namespace Shopee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        ShopeeDBContext context = new ShopeeDBContext();

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(string username, string password, string name,string phone, string email)
        {
            var user = context.Users.SingleOrDefault(u => u.Username == username);

            if (user != null)
            {
                return BadRequest("Username is exist!");
            }
            else
            {
                try
                {
                    User newUser = new User()
                    {
                        Username = username,
                        Password = password,
                        Name = name,
                        Email = email,
                        Phone = int.Parse(phone),
                        Role = 3
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    return Ok(newUser);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }   
        }
    }
}
