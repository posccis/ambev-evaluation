using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public abstract class PaymentMethodBase
    {
        public decimal TotalCharge { get; set; }
        public PaymentType Type { get; set; }
        public DateTime CreatedOn => DateTime.Now;
    }
}
