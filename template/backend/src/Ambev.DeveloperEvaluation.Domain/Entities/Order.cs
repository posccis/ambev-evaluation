using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Validation;


namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Order : BaseEntity, IOrder
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
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
        public List<OrderItem> Items { get; set; }
        public Address ShippingAddress { get; set; }
        public PaymentMethodBase PaymentMethod { get; set; }

        public Order(Guid customerId, int branchId, Guid shippingAddressId)
        {
            CustomerId = customerId;
            BranchId = branchId;
            ShippingAddressId = shippingAddressId;
            CreatedOn = DateTime.UtcNow;
            Status = OrderStatus.Created;
        }

        public void AddOrderItems(List<OrderItem> items) 
        {
            items.ForEach(i => { i.OrderId = Id; i.Discount = i.CalculateDiscount(); });
            Items.AddRange(items);
            Discount += items.Sum(i => i.Discount);
        }
        public ValidationResultDetail Validate()
        {
            var validator = new OrderValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
