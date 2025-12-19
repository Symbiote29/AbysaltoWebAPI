using AbysaltoWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AbysaltoWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AbysaltoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ApiContext _context;

        public CartController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost("items")]
        public async Task<IActionResult> AddEditCartItem([FromBody] AddCartItemDTO request)
        {
            var cart = await _context.carts.Include(c => c.items).FirstOrDefaultAsync(i => i.userId == request.userId);

            if(cart == null)
            {
                cart = new Cart
                {
                    cartId = Guid.NewGuid(),
                    userId = request.userId,
                    createdAt = DateTime.UtcNow,
                    updatedAt = DateTime.UtcNow,
                };

                _context.carts.Add(cart);
            }

            var existingItem = cart.items.FirstOrDefault(i => i.productId == request.productId);

            if(existingItem != null)
            {
                existingItem.itemPrice = request.itemPrice;
                existingItem.quantity = request.quantity;
                existingItem.updatedAt = DateTime.UtcNow;
            }
            else
            {
                var newItem = (new CartItem
                {
                    itemId = Guid.NewGuid(),
                    cartId = cart.cartId,
                    productId = request.productId,
                    productName = request.productName,
                    quantity = request.quantity,
                    itemPrice = request.itemPrice,
                    createdAt = DateTime.UtcNow,
                    updatedAt = DateTime.UtcNow,
                });

                _context.cartItems.Add(newItem);
            }

            cart.updatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new JsonResult(Ok(request));
        }
    }
}
