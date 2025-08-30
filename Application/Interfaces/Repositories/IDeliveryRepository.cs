using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IDeliveryRepository : IRepository<Delivery>
    {
        Task<Delivery?> GetByOrderAsync(Guid orderId);
        Task<IEnumerable<Delivery>> GetPendingDeliveriesAsync();
    }
}
