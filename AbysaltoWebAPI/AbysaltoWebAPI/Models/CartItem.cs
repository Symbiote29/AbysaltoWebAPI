using System.ComponentModel.DataAnnotations;

namespace AbysaltoWebAPI.Models
{
    public class CartItem
    {
        [Key]
        public Guid itemId {  get; set; }
        public Guid cartId { get; set; }
        public int productId { get; set; }
        public String productName { get; set; } = string.Empty;
        public decimal itemPrice { get; set; }
        public int quantity { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public Cart cart { get; set; } = new();
    }
}
