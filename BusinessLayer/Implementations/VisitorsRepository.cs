using DataAccessLayer.Entities;
using DataAccessLayer;
using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class VisitorsRepository : IVisitorsRepository
    {
        private readonly DataBaseContext _context;

        public VisitorsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Visitors>> GetAll(bool includeOrders = false, bool includeReservations = false)
        {
            IQueryable<Visitors> query = _context.visitors;

            if (includeOrders)
                query = query.Include(t => t.orders);

            if (includeReservations)
                query = query.Include(t => t.reservations);

            return await query.ToListAsync();
        }

        public async Task<Visitors> GetById(int ID, bool includeOrder = false, bool includeReservation = false)
        {
            IQueryable<Visitors> query = _context.visitors.Where(t => t.ID == ID);

            if (includeOrder)
                query = query.Include(t => t.orders);

            if (includeReservation)
                query = query.Include(t => t.reservations);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Save(Visitors visitor)
        {
            if (visitor.ID == 0)
                _context.visitors.Add(visitor);
            else
                _context.Entry(visitor).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Visitors visitor)
        {
            _context.visitors.Remove(visitor);
            await _context.SaveChangesAsync();
        }
    }
}
