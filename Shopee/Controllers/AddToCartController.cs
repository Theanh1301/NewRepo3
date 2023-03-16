using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopee.Data;
using Shopee.Models;

namespace Shopee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddToCartController : ControllerBase
    {
        ShopeeDBContext _context = new ShopeeDBContext();
        [HttpGet]
        [Route("ShoppingCart/{id:int}")]
        public async Task<ActionResult<CartItem>> GetCart(int id)
        {
            try
            {
                var shoppingCart = _context.ShoppingCarts.Select(s => new CartItem()
                {
                    ProductName = s.Product.ProductName,
                    Name = s.User.Name
                    
                } ).ToList();
                return Ok(shoppingCart);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> AddToCart(int productId, int quantity, int userId)
        {
            
            try
            {
                var shoppingCart = _context.ShoppingCarts.Where(s => s.ProductId == productId 
                && s.UserId == userId).FirstOrDefault();

                if (shoppingCart == null)
                {
                    shoppingCart = new ShoppingCart
                    {
                        UserId = userId,
                        ProductId = productId,
                        Quantity = quantity,
                    };
                    _context.ShoppingCarts.Add(shoppingCart);
                }
                else
                {
                    shoppingCart.Quantity += quantity;
                }
                _context.SaveChanges();
                return Ok(shoppingCart);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
