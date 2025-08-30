using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public ICustomerRepository Customers { get; }
        public IOrderRepository Orders { get; }
        public IProductRepository Products { get; }
        public IPaymentRepository Payments { get; }
        public IDeliveryRepository Deliveries { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(
            AppDbContext context,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IPaymentRepository paymentRepository,
            IDeliveryRepository deliveryRepository,
            IUserRepository userRepository)
        {
            _context = context;

            Customers = customerRepository;
            Orders = orderRepository;
            Products = productRepository;
            Payments = paymentRepository;
            Deliveries = deliveryRepository;
            Users = userRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
