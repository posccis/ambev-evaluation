using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interfaces;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class OrderItem : BaseEntity, IOrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductSku { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public Order Order { get; set; }

        public decimal CalculateDiscount()
        {

            if (Quantity >= 4 && Quantity <= 9)
                return UnitPrice * Quantity * 0.10m;

            if (Quantity >= 10 && Quantity <= 20)
                return UnitPrice * Quantity * 0.20m;

            return 0m;
        }
    }
}