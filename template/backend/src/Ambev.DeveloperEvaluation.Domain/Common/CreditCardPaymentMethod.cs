using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public class CredidCardPaymentMethod : PaymentMethodBase
    {
        public Guid CreditCardId { get; set; }
        public int InstallmentNumber { get; set; }
        public decimal InstallmentValue { get; set; }
    }
}
