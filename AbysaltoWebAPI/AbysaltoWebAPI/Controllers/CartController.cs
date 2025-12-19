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

                cart.items.Add(newItem);
                _context.cartItems.Add(newItem);
            }

            cart.updatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new CartResponseDTO
            {
                cartId = cart.cartId,
                userId = cart.userId,
                responseItems = cart.items.Select(i => new CartItemResponseDTO
                {
                    cartItemId = i.itemId,
                    productId = i.productId,
                    productName = i.productName,
                    itemPrice = i.itemPrice,
                    quantity = i.quantity,
                }).ToList(),
            });
        }

        [HttpGet("cart/{userId}")]
        public async Task<IActionResult> CheckItemsInCart(int userId)
        {
            var cart = await _context.carts.Include(c => c.items).FirstOrDefaultAsync(c => c.userId == userId);

            if(cart == null)
            {
                return NotFound();
            }

            var response = new CartResponseDTO
            {
                cartId = cart.cartId,
                userId = userId,
                responseItems = cart.items.Select(i => new CartItemResponseDTO
                {
                    cartItemId = i.itemId,
                    productId = i.productId,
                    productName = i.productName,
                    itemPrice = i.itemPrice,
                    quantity = i.quantity,
                }).ToList(),
            };

            return Ok(response);
        }

        [HttpDelete("items/{itemId}")]
        public async Task<IActionResult> RemoveItemsFromCart(Guid itemId)
        {
            var item = await _context.cartItems.FirstOrDefaultAsync(c => c.itemId == itemId);

            if (item == null)
            {
                return NotFound();
            }

            var cart = await _context.carts.Include(c => c.items).FirstOrDefaultAsync(c => c.cartId == item.cartId);

            if (cart == null)
            {
                return NotFound();
            }

            _context.cartItems.Remove(item);
            cart.updatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();  

            var response = new CartResponseDTO{
                cartId = cart.cartId,
                userId = cart.userId,
                responseItems = cart.items.Select(i => new CartItemResponseDTO
                {
                    cartItemId = i.itemId,
                    productId = i.productId,
                    productName = i.productName,
                    quantity = i.quantity,
                    itemPrice = i.itemPrice,
                }).ToList(),
            };

            return Ok(response);
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> DeleteEntireUserCart(Guid cartId)
        {
            var cart = await _context.carts.FirstOrDefaultAsync(c => c.cartId == cartId);

            if (cart == null)
            {
                return NotFound();
            }

            _context.carts.Remove(cart);
            cart.updatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var response = new CartResponseDTO
            {
                cartId = cart.cartId,
                userId = cart.userId,
                responseItems = cart.items.Select(i => new CartItemResponseDTO
                {
                    cartItemId = i.itemId,
                    productId = i.productId,
                    productName = i.productName,
                    quantity = i.quantity,
                    itemPrice = i.itemPrice,
                }).ToList(),
            };

            return Ok(response);
        }
    }
}
