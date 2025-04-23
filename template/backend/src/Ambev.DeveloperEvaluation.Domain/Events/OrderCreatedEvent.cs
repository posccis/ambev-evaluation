using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class OrderCreatedEvent
    {
        public Guid OrderId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
