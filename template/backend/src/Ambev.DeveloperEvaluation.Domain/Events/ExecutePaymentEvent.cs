using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class ExecutePaymentEvent
    {
        public PaymentMethodBase PaymentMethod { get; set; }
        public Guid OrderId { get; set; }

        public ExecutePaymentEvent(PaymentMethodBase paymentMethod, Guid orderId)
        {
            PaymentMethod = paymentMethod;
            OrderId = orderId;
        }
    }
}
