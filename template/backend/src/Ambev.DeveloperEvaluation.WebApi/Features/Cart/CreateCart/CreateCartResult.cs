using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart
{
    public class CreateCartResult
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal Subtotal => Items.Sum(i => i.Total);
        public decimal Total => Subtotal;
    }
}
