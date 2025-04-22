using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.AddItemToCart
{
    public class AddItemToCartResult
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public DateTime UpdatedOn { get; set; }

        public decimal Subtotal => Items.Sum(i => i.Total);
        public decimal Total => Subtotal;
    }
}
