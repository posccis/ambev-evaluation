using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.AddItemToCart
{
    public class AddItemToCartResult
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public DateTime UpdatedOn { get; set; }

        public decimal Subtotal => Items.Sum(i => i.Total);
        public decimal Total => Subtotal;
    }

}
