using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface IOrder
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }             
        public Customer Customer { get;  set; }          
        public DateTime CreatedAt { get;  set; }         
        public DateTime? PaidAt { get;  set; }           
        public DateTime? DeliveredAt { get;  set; }      
        public OrderStatus Status { get;  set; }         
        public decimal TotalAmount { get;  set; }        
        public decimal Discount { get;  set; }
        public decimal ShippingValue { get; set; }
        public decimal FinalAmount => TotalAmount + ShippingValue - Discount;
        public List<OrderItem> Items { get;  set; }      
        public Address ShippingAddress { get;  set; }    
        public PaymentMethodBase PaymentMethod { get;  set; }
    }
}
