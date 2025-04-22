using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart
{
    public class CreateCartResponse
    {
        public Guid CartId { get; set; }
        public Guid CustomerId { get; set; }
        public List<CartItem> CartItems { get; set; } = new();
    }
}
