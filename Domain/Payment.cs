using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Payment : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime PaymentDate { get; private set; } = DateTime.UtcNow;
        public PaymentMethod PaymentMethod { get; private set; }
        public string Status { get; private set; } = "Pending";

        private Payment() { }
        public Payment(Guid orderId, decimal amount, PaymentMethod method)
        {
            OrderId = orderId; Amount = amount; PaymentMethod = method;
        }

        public void Approve() { Status = "Approved"; Touch(); }
        public void Reject() { Status = "Rejected"; Touch(); }
    }

    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer,
        CashOnDelivery
    }
}
