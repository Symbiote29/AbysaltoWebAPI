namespace AbysaltoWebAPI.Models
{
    public class CartItemResponseDTO
    {
        public Guid cartItemId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; } = string.Empty;
        public decimal itemPrice { get; set; }
        public int quantity { get; set; }
    }
}
