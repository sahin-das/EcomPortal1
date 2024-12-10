using EcomPortal.Models;
using EcomPortal.Models.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System;

namespace EcomPortal.Repositories
{
    public class OrderRepository : CrudRepository<Order>, ICrudRepository<Order>
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderProducts)
                .ToListAsync();
        }

        public new async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
