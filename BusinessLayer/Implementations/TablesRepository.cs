using DataAccessLayer.Entities;
using DataAccessLayer;
using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class TablesRepository : ITablesRepository
    {
        private readonly DataBaseContext _context;

        public TablesRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tables>> GetAll(bool includeReservations = false, bool includeOrders = false)
        {
            IQueryable<Tables> query = _context.tables;

            if (includeReservations)
                query = query.Include(t => t.reservationTables);

            if (includeOrders)
                query = query.Include(t => t.orders);

            return await query.ToListAsync();
        }

        public async Task<Tables> GetById(int ID, bool includeReservation = false, bool includeOrder = false)
        {
            IQueryable<Tables> query = _context.tables.Where(t => t.ID == ID);

            if (includeReservation)
                query = query.Include(t => t.reservationTables);

            if (includeOrder)
                query = query.Include(t => t.orders);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Save(Tables table)
        {
            if (table.ID == 0)
                _context.tables.Add(table);
            else
                _context.Entry(table).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Tables table)
        {
            _context.tables.Remove(table);
            await _context.SaveChangesAsync();
        }
    }
}
