using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interfaces;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class OrderItem : BaseEntity, IOrderItem
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductSku { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn => DateTime.Now;
        public DateTime UpdatedOn { get; set; }
    }
}