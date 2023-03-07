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
        Validation validation = new Validation();
        ShopeeDBContext context = new ShopeeDBContext();

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            var user = context.Users.SingleOrDefault(u => u.Username == register.Username);

            if (user != null)
            {
                return Ok(new APIResponse
                {
                    Success = false,
                    Msg = $"Username already exist!"
                });
            }
            else if (!register.Password.Equals(register.RePassword))
            {
                return Ok(new APIResponse
                {
                    Success = false,
                    Msg = $"Password and re-password are not same!"
                });
            }
            else if (!validation.IsEmail(register.Email))
            {
                return Ok(new APIResponse
                {
                    Success = false,
                    Msg = $"Email {register.Email} is not true!"
                });
            }
            else if (!validation.IsNumber(register.Phone))
            {
                return Ok(new APIResponse
                {
                    Success = false,
                    Msg = $"Phone must be digit and 10 digit!"
                });
            }
            else
            {
                try
                {
                    User newUser = new User()
                    {
                        Username = register.Username,
                        Password = register.Password,
                        Name = register.Name,
                        Email = register.Email,
                        Phone = int.Parse(register.Phone),
                        Role = 3
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    return Ok(new APIResponse
                    {
                        Success = true,
                        Msg = $"Register Success, Hello Mr/Mrs {newUser.Name}"
                    });
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }
    }
}
