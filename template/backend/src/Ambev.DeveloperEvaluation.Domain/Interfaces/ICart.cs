using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface ICart
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal Subtotal => Items.Sum(i => i.Total);
        public decimal Total => Subtotal;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
