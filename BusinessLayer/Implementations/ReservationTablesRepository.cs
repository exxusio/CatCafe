using DataAccessLayer.Entities;
using DataAccessLayer;
using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class ReservationTablesRepository : IReservationTablesRepository
    {
        private readonly DataBaseContext _context;

        public ReservationTablesRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservationTables>> GetAll(bool includeTables = false)
        {
            IQueryable<ReservationTables> query = _context.reservationTables;

            if (includeTables)
                query = query.Include(t => t.table);

            return await query.ToListAsync();
        }

        public async Task<ReservationTables> GetById(int ID, bool includeTable = false)
        {
            IQueryable<ReservationTables> query = _context.reservationTables.Where(t => t.ID == ID);

            if (includeTable)
                query = query.Include(t => t.table);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Save(ReservationTables reservationTable)
        {
            if (reservationTable.ID == 0)
                _context.reservationTables.Add(reservationTable);
            else
                _context.Entry(reservationTable).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(ReservationTables reservationTable)
        {
            _context.reservationTables.Remove(reservationTable);
            await _context.SaveChangesAsync();
        }
    }
}
