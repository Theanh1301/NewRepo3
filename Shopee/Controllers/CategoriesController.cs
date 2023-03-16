using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopee.Data;
using Shopee.Models;

namespace Shopee.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ShopeeDBContext _context = new ShopeeDBContext();

        [HttpGet]
        public async Task<ActionResult<Category>> GetAll()
        {
            try
            {
                var categories = _context.Categories.ToList();
                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("category/{id:int}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            try
            {
                var categories = _context.Categories.Find(id);

                if (categories != null)
                    return Ok(categories);
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
