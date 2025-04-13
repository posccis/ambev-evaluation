using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Order : BaseEntity, IOrder
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreatedOn => DateTime.Now;
        public DateTime? PaidOn { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount => //todo: ADICIONAR O SUM DO oRDERiTEMS;
        public decimal FinalAmount => TotalAmount + ShippingValue - Discount;    // Valor final (calculado)
        public decimal Discount { get; set; }
        public decimal ShippingValue { get; set; }
        public List<OrderItem> Items { get; set; }
        public Address ShippingAddress { get; set; }
        public PaymentMethodBase PaymentMethod { get; set; }


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
