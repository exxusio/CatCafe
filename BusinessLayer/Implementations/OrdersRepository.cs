using DataAccessLayer.Entities;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly DataBaseContext _context;

        public OrdersRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Orders>> GetAll(bool includeContents = false, bool includeTables = false)
        {
            IQueryable<Orders> query = _context.orders;

            if (includeContents)
                query = query.Include(t => t.contents);

            if (includeTables)
                query = query.Include(t => t.table);

            return await query.ToListAsync();
        }

        public async Task<Orders> GetById(int ID, bool includeContent = false, bool includeTable = false)
        {
            IQueryable<Orders> query = _context.orders.Where(t => t.ID == ID);

            if (includeContent)
                query = query.Include(t => t.contents);

            if (includeTable)
                query = query.Include(t => t.table);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Save(Orders order)
        {
            if (order.ID == 0)
                _context.orders.Add(order);
            else
                _context.Entry(order).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Orders order)
        {
            _context.orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
