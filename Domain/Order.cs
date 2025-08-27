using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; private set; }
        public string Status { get; private set; } = "Pending";
        public decimal TotalAmount { get; private set; }

        public List<OrderItem> Items { get; private set; } = new();

        private Order() { }
        public Order(Guid customerId) { CustomerId = customerId; }

        public void AddItem(Guid productId, int quantity, decimal unitPrice)
        {
            Items.Add(new OrderItem(productId, quantity, unitPrice));
            Recalculate();
        }

        public void UpdateStatus(string status) { Status = status; Touch(); }

        private void Recalculate()
        {
            TotalAmount = Items.Sum(i => i.Quantity * i.UnitPrice);
        }
    }

    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        private OrderItem() { }
        public OrderItem(Guid productId, int quantity, decimal unitPrice)
        {
            ProductId = productId; Quantity = quantity; UnitPrice = unitPrice;
        }
    }
}
