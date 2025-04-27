using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Shopping.GetOrder
{
    public class GetOrderResult
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public int BranchId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? PaidOn { get; set; }
        public DateTime? DeliveredOn { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal ShippingValue { get; set; }
        public Guid ShippingAddressId { get; set; }

        public GetOrderResult(Guid orderId, DateTime createdOn, decimal total)
        {
            Id = orderId;
            CreatedOn = createdOn;
            FinalAmount = total;
        }
    }
}
