using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<Product>> GetAll()
        {
            try
            {
                var products = _context.Products.Select(p => new ProductDTO() { CategoryName = p.Category.CategoryName, Saler = p.Sale.Name,
                    ProductName = p.ProductName, Image = p.Image, UnitPrice = p.UnitPrice, ProductId = p.ProductId,
                    UnitInStock = p.UnitInStock, Manufacturer = p.Manufacturer, Details = p.Details } ).ToList();
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
        [HttpGet]
        [Route("products/category/{id:int}")]
        public async Task<ActionResult<Product>> GetProductByCategoryId(int id)
        {
            try
            {
                var result = _context.Products.Where(m => m.CategoryId == id).ToList();

                if (result == null)
                    return NotFound();
                else
                    return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Product>> Create(string name, decimal price, int unitInStock
            , string manufacturer, string image, string details, int cateId, int saleId)
        {
            try
            {
                Product product = new Product
                {
                    ProductName = name,
                    UnitPrice = price,
                    UnitInStock = unitInStock,
                    Manufacturer = manufacturer,
                    Image = image,
                    Details = details,
                    CategoryId = cateId,
                    SaleId = saleId
                };
                _context.Products.Add(product);
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
        public async Task<ActionResult<Product>> Delete(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                    return NotFound();
                else
                    _context.Products.Remove(product);
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
        public async Task<ActionResult<Product>> Edit(int id, string name, decimal price, int unitInStock
            , string manufacturer, string image, string details, int cateId)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                    return NotFound();
                else
                {
                    product.ProductName = name;
                    product.UnitPrice = price;
                    product.UnitInStock = unitInStock;
                    product.Manufacturer = manufacturer;
                    product.Image = image;
                    product.Details = details;
                    product.CategoryId = cateId;
                }
                _context.Products.Update(product);
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
