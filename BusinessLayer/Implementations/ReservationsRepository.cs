using DataAccessLayer.Entities;
using DataAccessLayer;
using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class ReservationsRepository : IReservationsRepository
    {
        private readonly DataBaseContext _context;

        public ReservationsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservations>> GetAll(bool includeCats = false, bool includeTables = false)
        {
            IQueryable<Reservations> query = _context.reservations;

            if (includeCats)
                query = query.Include(t => t.reservationCats);

            if (includeTables)
                query = query.Include(t => t.reservationTables);

            return await query.ToListAsync();
        }

        public async Task<Reservations> GetById(int ID, bool includeCat = false, bool includeTable = false)
        {
            IQueryable<Reservations> query = _context.reservations.Where(t => t.ID == ID);


            if (includeCat)
                query = query.Include(t => t.reservationCats);

            if (includeTable)
                query = query.Include(t => t.reservationTables);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Save(Reservations reservation)
        {
            if (reservation.ID == 0)
                _context.reservations.Add(reservation);
            else
                _context.Entry(reservation).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Reservations reservation)
        {
            _context.reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
