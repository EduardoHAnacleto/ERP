using Application.Interfaces.Repositories;
using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly AppDbContext _context;

        public DeliveryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Delivery> AddAsync(Delivery entity)
        {
            _context.Deliveries.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Deliveries.FindAsync(id);
            if (entity != null)
            {
                _context.Deliveries.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Delivery>> GetAllAsync() =>
            await _context.Deliveries.ToListAsync();

        public async Task<Delivery> GetByIdAsync(Guid id) =>
            await _context.Deliveries.FindAsync(id);

        public async Task<Delivery?> GetByOrderAsync(Guid orderId)
        {
            return await _context.Deliveries
                                 .FirstOrDefaultAsync(d => d.OrderId == orderId);
        }

        public Task<IEnumerable<Delivery>> GetPendingDeliveriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Delivery entity)
        {
            _context.Deliveries.Update(entity);
            await _context.SaveChangesAsync();
        }

        Task IRepository<Delivery>.AddAsync(Delivery entity)
        {
            return AddAsync(entity);
        }
    }
}
