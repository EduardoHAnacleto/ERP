using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StockMovement : BaseEntity
    {
        public Guid ProductId { get; private set; }
        public int QuantityChange { get; private set; }
        public DateTime MovementDate { get; private set; } = DateTime.UtcNow;
        public string Reason { get; private set; } = string.Empty;

        public StockMovement() { }
        public StockMovement(Guid productId, int quantityChange, string reason)
        {
            ProductId = productId; QuantityChange = quantityChange; Reason = reason;
        }
    }
}
