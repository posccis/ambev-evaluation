using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Shopping.CreateOrder
{
    public class CreateOrderResponse
    {
        public Guid OrderId { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal Total { get; set; }

        public CreateOrderResponse(Guid orderId, DateTime createdOn, decimal total)
        {
            OrderId = orderId;
            CreatedOn = createdOn;
            Total = total;
        }
    }
}
