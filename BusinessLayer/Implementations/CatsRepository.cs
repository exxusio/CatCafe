using DataAccessLayer.Entities;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class CatsRepository : ICatsRepository
    {
        private readonly DataBaseContext _context;

        public CatsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cats>> GetAll(bool includeBreeds = false, bool includeReservations = false)
        {
            IQueryable<Cats> query = _context.cats;

            if (includeBreeds)
                query = query.Include(t => t.breed);

            if (includeReservations)
                query = query.Include(t => t.reservationCats);

            return await query.ToListAsync();
        }

        public async Task<Cats> GetById(int ID, bool includeBreed = false, bool includeReservation = false)
        {
            IQueryable<Cats> query = _context.cats.Where(t => t.ID == ID);

            if (includeBreed)
                query = query.Include(t => t.breed);

            if (includeReservation)
                query = query.Include(t => t.reservationCats);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Save(Cats cat)
        {
            if (cat.ID == 0)
                _context.cats.Add(cat);
            else
                _context.Entry(cat).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Cats cat)
        {
            _context.cats.Remove(cat);
            await _context.SaveChangesAsync();
        }
    }
}
