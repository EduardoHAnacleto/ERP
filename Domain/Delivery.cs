using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Delivery : BaseEntity
    {
        public Guid OrderId { get; set; }
        public DeliveryStatus Status { get; set; }
        public string Address { get; set; }
        public string ExtraDeliveryInformation { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? DeliveredDate { get; set; }

        public Order Order { get; set; }
    }

    public enum DeliveryStatus
    {
        Pending,
        Shipped,
        Delivered,
        Canceled
    }
}
