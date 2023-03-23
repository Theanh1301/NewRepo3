using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopee.Data;
using Shopee.Models;
using System.Net.Mail;

namespace Shopee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        Validation _validation = new Validation();
        ShopeeDBContext _context = new ShopeeDBContext();

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == register.Username);

            if (user != null)
            {
                return BadRequest();
            }
            else if (!register.Password.Equals(register.RePassword))
            {
                return BadRequest();
            }
            else if (!_validation.IsEmail(register.Email))
            {
                return BadRequest();
            }
            else if (!_validation.IsNumber(register.Phone))
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    Models.User newUser = new Models.User()
                    {
                        Username = register.Username,
                        Password = register.Password,
                        Name = register.Name,
                        Email = register.Email,
                        Phone = int.Parse(register.Phone),
                        Role = 3
                    };

                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();

                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }
    }
}
