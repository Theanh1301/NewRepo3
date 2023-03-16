using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopee.Data;
using Shopee.Models;

namespace Shopee.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ShopeeDBContext _context = new ShopeeDBContext();
    
        [HttpGet]
        [Authorize]


        public async Task<ActionResult<Product>> GetAll()
        {
            try
            {
                var products = _context.Products.ToList();
                return Ok(products);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("search/{searchKey}")]
        public async Task<ActionResult<Product>> Search(string searchKey)
        {
            try
            {
                if (searchKey == null) return NotFound();

                var result = _context.Products
                    .Where(p => p.ProductName.Contains(searchKey.TrimStart().TrimEnd()));

                if (result.Any())
                   return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("products/{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var result = _context.Products.Find(id);

                if (result == null) 
                    return NotFound();
                else
                    return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }       
    } 
}
