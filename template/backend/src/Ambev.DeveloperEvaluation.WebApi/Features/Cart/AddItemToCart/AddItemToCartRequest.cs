namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.AddItemToCart
{
    public class AddItemToCartRequest
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
