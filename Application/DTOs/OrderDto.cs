using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CreateOrderDto
    {
        public Guid CustomerId { get; set; }
        public List<Guid> ProductIds { get; set; } = new();
    }

    public class UpdateOrderStatusDto
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
