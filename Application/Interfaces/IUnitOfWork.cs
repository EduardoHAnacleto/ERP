using Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IPaymentRepository Payments { get; }
        IDeliveryRepository Deliveries { get; }
        IUserRepository Users { get; }

        Task<int> SaveChangesAsync();
    }
}
