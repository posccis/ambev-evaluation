using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Order.CreateOrder
{
    public class CreateOrderRequest
    {
        public Guid CartId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ShippingAddressId { get; set; }
        public int BranchId { get; set; }
        public CredidCardPaymentMethod CreditCard { get; set; }
        public PixPaymentMethod Pix { get; set; }
    }
}
