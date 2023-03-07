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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = _context.Categories.ToList();
                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("getbyid")]
        public async Task<IActionResult> GetById(CategoryData categoryData)
        {
            try
            {
                var categories = _context.Categories.Find(categoryData.CategoryId);

                if (categories != null)
                    return Ok(categories);
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
