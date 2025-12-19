namespace AbysaltoWebAPI.Models
{
    public class CartResponseDTO
    {
        public Guid cartId {  get; set; }
        public int userId { get; set; }
        public List<CartItemResponseDTO> responseItems {  get; set; } = new List<CartItemResponseDTO>();
    }
}