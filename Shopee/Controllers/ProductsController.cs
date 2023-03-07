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
        public async Task<IActionResult> GetAll()
        {
            
            try
            {
                var products = _context.Products.ToList();
                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("getbyname")]
        public async Task<IActionResult> GetByName(ProductData productData)
        {
            try
            {
                var products = _context.Products
                    .Where(p => p.ProductName.Contains(productData.ProductName))
                    .ToList();

                if (products != null)
                    return Ok(products);
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("getdetailsbyid")]
        public async Task<IActionResult> GetDetailsById(ProductData productData)
        {
            try
            {
                var products = _context.Products.Find(productData.ProductId);
                if (products != null)
                    return Ok(products);
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("getbypid")]
        public async Task<IActionResult> GetAllByCId(ProductData productData)
        {
            try
            {
                var products = _context.Products
                .Where(p => p.CategoryId == productData.CategoryID);

                if (products != null)
                    return Ok(products);
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
