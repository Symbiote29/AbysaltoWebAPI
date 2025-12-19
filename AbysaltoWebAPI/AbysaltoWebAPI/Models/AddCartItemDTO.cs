namespace AbysaltoWebAPI.Models
{
    public class AddCartItemDTO
    {
        public int userId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; } = string.Empty;
        public int quantity { get; set; }
        public decimal itemPrice { get; set; }
    }
}
