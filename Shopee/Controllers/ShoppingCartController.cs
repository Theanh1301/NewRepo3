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
        ShopeeDBContext _context = new ShopeeDBContext();
        [HttpGet]
        [Route("ShoppingCart/{id:int}")]
        public async Task<ActionResult<ShoppingCartDTO>> GetCart(int id)
        {
            try
            {
                    var shoppingCart = _context.ShoppingCarts.Select(s => new ShoppingCartDTO()
                    {
                        Sid = s.Sid,
                        ProductName = s.Product.ProductName,
                        Name = s.User.Name,
                        Quantity = s.Quantity,
                        UserId =s.UserId,
                        TotalPrice = (decimal)((decimal)s.Quantity * s.Product.UnitPrice)
                    }).Where(s => s.UserId == id).ToList();
                    return Ok(shoppingCart);
                                       
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<ShoppingCart>> AddToCart([FromBody] CartModel cm)
        {
            
            try
            {
                var shoppingCart = _context.ShoppingCarts.Where(s => s.ProductId == cm.ProductId 
                && s.UserId == cm.UserId).FirstOrDefault();

                if (shoppingCart == null)
                {
                    shoppingCart = new ShoppingCart
                    {
                        UserId = cm.UserId,
                        ProductId = cm.ProductId,
                        Quantity = cm.Quantity,
                    };
                    _context.ShoppingCarts.Add(shoppingCart);
                }
                else
                {
                    shoppingCart.Quantity += cm.Quantity;
                }
                await _context.SaveChangesAsync();
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
                var cartItem = _context.ShoppingCarts.Where(s => s.ProductId == productId
                && s.UserId == userId).FirstOrDefault();

                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity -= 1;
                }
                else
                {
                    _context.ShoppingCarts.Remove(cartItem);
                }              
                await _context.SaveChangesAsync();
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
                var cartItem = _context.ShoppingCarts.Where(s => s.ProductId == productId
                && s.UserId == userId).FirstOrDefault();

                _context.ShoppingCarts.Remove(cartItem);
                await _context.SaveChangesAsync();
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
