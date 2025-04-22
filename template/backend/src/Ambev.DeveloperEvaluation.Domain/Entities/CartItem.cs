using Ambev.DeveloperEvaluation.Domain.Interfaces;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class CartItem : ICartItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public Cart Cart { get; set; }

        public CartItem GenerateCartItem(Product product, int quantity, Guid cartId)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            CartId = cartId;
            UnitPrice = product.Price;
            Quantity = quantity;
            Total = product.Price * quantity;
            return this;
        }
    }
}
