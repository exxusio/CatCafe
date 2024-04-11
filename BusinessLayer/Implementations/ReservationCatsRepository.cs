using DataAccessLayer.Entities;
using DataAccessLayer;
using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class ReservationCatsRepository : IReservationCatsRepository
    {
        private readonly DataBaseContext _context;

        public ReservationCatsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservationCats>> GetAll(bool includeCats = false)
        {
            IQueryable<ReservationCats> query = _context.reservationCats;

            if (includeCats)
                query = query.Include(t => t.cat);

            return await query.ToListAsync();
        }

        public async Task<ReservationCats> GetById(int ID, bool includeCat = false)
        {
            IQueryable<ReservationCats> query = _context.reservationCats.Where(t => t.ID == ID);

            if (includeCat)
                query = query.Include(t => t.cat);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Save(ReservationCats reservationCat)
        {
            if (reservationCat.ID == 0)
                _context.reservationCats.Add(reservationCat);
            else
                _context.Entry(reservationCat).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(ReservationCats reservationCat)
        {
            _context.reservationCats.Remove(reservationCat);
            await _context.SaveChangesAsync();
        }
    }
}
