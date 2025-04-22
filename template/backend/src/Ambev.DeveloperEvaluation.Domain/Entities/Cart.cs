using Ambev.DeveloperEvaluation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart : ICart
    {
        public Guid Id { get;  set; }                     
        public Guid CustomerId { get;  set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();      
        public decimal Subtotal => Items.Sum(i => i.Total); 
        public decimal Total => Subtotal;             
        public DateTime CreatedOn { get;  set; }
        public DateTime UpdatedOn { get;  set; }
        public bool IsActive { get;  set; }

        public Cart GenerateNewCart(Guid customerId) 
        {
            CustomerId = customerId;
            Items = new();
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
            IsActive = true;

            return this;
        }
    }
}
