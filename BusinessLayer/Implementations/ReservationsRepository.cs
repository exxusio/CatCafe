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

        public async Task<IEnumerable<Reservations>> GetAll()
        {
            return await _context.reservations.ToListAsync();
        }

        public async Task<Reservations> GetById(int ID)
        {
            return await _context.reservations.FirstOrDefaultAsync(x => x.ID == ID);
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
