using AbysaltoWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AbysaltoWebAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Cart> carts { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base (options) 
        {

        }
    }
}
