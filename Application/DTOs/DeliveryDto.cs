using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DeliveryDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public class CreateDeliveryDto
    {
        public Guid OrderId { get; set; }
        public string Address { get; set; } = string.Empty;
    }

    public class UpdateDeliveryStatusDto
    {
        public Guid DeliveryId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
