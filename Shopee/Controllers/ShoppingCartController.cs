using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopee.Data;
using Shopee.Models;

namespace Shopee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
       /* public decimal GetTotal(int userId)
        {
            decimal? total = (from cartItems in _context.ShoppingCarts
                              where cartItems.ProductId == userId
                              select (int?)cartItems.Quantity * cartItems.Product.UnitPrice).Sum();
            return total ?? 0;
        }*/
        ShopeeDBContext _context = new ShopeeDBContext();
        [HttpGet]
        [Route("ShoppingCart/{id:int}")]
        public async Task<ActionResult<ShoppingCartDTO>> GetCart(int id)
        {
            try
            {
                var cart = _context.ShoppingCarts.Where(s => s.UserId == id).FirstOrDefault();
                if (cart == null)
                    return NotFound();
                else
                {
                    var shoppingCart = _context.ShoppingCarts.Select(s => new ShoppingCartDTO()
                    {
                        Sid = s.Sid,
                        ProductName = s.Product.ProductName,
                        Name = s.User.Name,
                        Quantity = s.Quantity,
                        TotalPrice = (decimal)((decimal)s.Quantity * s.Product.UnitPrice)
                    }).ToList();
                    return Ok(shoppingCart);
                }                              
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("Add")]
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
                return Ok("Add To Cart Success!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpDelete]
        [Route("Remove")]
        public async Task<ActionResult<ShoppingCart>> Remove(int productId, int userId)
        {

            try
            {
                var shoppingCart = _context.ShoppingCarts.Where(s => s.ProductId == productId
                && s.UserId == userId).FirstOrDefault();

                if (shoppingCart.Quantity > 1)
                {
                    shoppingCart.Quantity -= 1;
                }
                else
                {
                    _context.ShoppingCarts.Remove(shoppingCart);
                }              
                _context.SaveChanges();
                return Ok("Remove Item Success!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpDelete]
        [Route("RemoveAll")]
        public async Task<ActionResult<ShoppingCart>> RemoveAll(int productId, int userId)
        {

            try
            {
                var shoppingCart = _context.ShoppingCarts.Where(s => s.ProductId == productId
                && s.UserId == userId).FirstOrDefault();

                _context.ShoppingCarts.Remove(shoppingCart);
                _context.SaveChanges();
                return Ok("Remove Item Success!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
