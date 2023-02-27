using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopee.Models;
using System.Net.Mail;

namespace Shopee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        Validation validation = new Validation();
        ShopeeDBContext context = new ShopeeDBContext();
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(string username, string password, string email, string phone, string name)
        {
            var user = context.Users.SingleOrDefault(u => u.Username == username);

            if (user != null)
            {
                return BadRequest("Username is exist!");
            }
            else if (!validation.IsEmail(email))
            {
                return BadRequest("Email is not valid!");
            }
            else if (!validation.IsNumber(phone))
            {
                return BadRequest("Phone must be digit!");
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
