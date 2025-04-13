using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public class PixPaymentMethod : PaymentMethodBase
    {
        public string KeyCode { get; set; }
        public string PayerDocument { get; set; }
        public decimal ExpireTime { get; set; }
    }
}
