using System.ComponentModel.DataAnnotations;

namespace AbysaltoWebAPI.Models
{
    public class Cart
    {
        [Key]
        public Guid cartId { get; set; }
        public int userId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public List<CartItem> items { get; set; } = new();
    }
}
