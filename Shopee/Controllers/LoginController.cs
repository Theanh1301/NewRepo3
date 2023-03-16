using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopee.Data;
using Shopee.Responsitories;


namespace Shopee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IAccountResponsitory accountRepos;

        public LoginController(IAccountResponsitory repos)
        {
            accountRepos = repos;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserModel userData)
        {
            try
            {
                var result = await accountRepos.SignInAsync(userData);

                if (string.IsNullOrEmpty(result))
                    return BadRequest("Invalid username or password!");
                else
                    return Ok(result);
                        $", Role: {userLogin.Role}",
                        Data = $"Token = Null"
                });
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"{ex.Message}");
            }
        }
    }
    
}
