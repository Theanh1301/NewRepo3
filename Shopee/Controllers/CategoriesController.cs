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
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Category>> Create(string name)
        {
            try
            {
                Category category = new Category
                {
                    CategoryName = name
                };
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return Ok("Create Success!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            try
            {
                var category = _context.Categories.Find(id);
                if (category == null)
                    return NotFound();
                else
                    _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return Ok("Remove success");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        [Route("Edit/{id:int}")]
        public async Task<ActionResult<Category>> Edit(int id, string name)
        {
            try
            {
                var category = _context.Categories.Find(id);
                if (category == null)
                    return NotFound();
                else
                    category.CategoryName = name;
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();

                return Ok("Edit success");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
