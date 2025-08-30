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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> AddAsync(Payment entity)
        {
            _context.Payments.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Payments.FindAsync(id);
            if (entity != null)
            {
                _context.Payments.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Payment>> GetAllAsync() =>
            await _context.Payments.ToListAsync();

        public async Task<Payment> GetByIdAsync(Guid id) =>
            await _context.Payments.FindAsync(id);

        public async Task<IEnumerable<Payment>> GetByOrderAsync(Guid orderId)
        {
            return await _context.Payments
                                 .Where(p => p.OrderId == orderId)
                                 .ToListAsync();
        }

        public async Task UpdateAsync(Payment entity)
        {
            _context.Payments.Update(entity);
            await _context.SaveChangesAsync();
        }

        Task IRepository<Payment>.AddAsync(Payment entity)
        {
            return AddAsync(entity);
        }
    }
}
