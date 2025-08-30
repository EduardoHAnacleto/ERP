using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string Method { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CreatePaymentDto
    {
        public Guid OrderId { get; set; }
        public string Method { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }

    public class UpdatePaymentStatusDto
    {
        public Guid PaymentId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
