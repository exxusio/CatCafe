using BusinessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class BreedsRepository : IBreedsRepository
    {
        private readonly DataBaseContext _context;

        public BreedsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Breeds>> GetAll()
        {
            return await _context.breeds.ToListAsync();
        }

        public async Task<Breeds> GetById(int ID)
        {
            return await _context.breeds.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task Save(Breeds breed)
        {
            if (breed.ID == 0)
                _context.breeds.Add(breed);
            else
                _context.Entry(breed).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Breeds breed)
        {
            _context.breeds.Remove(breed);
            await _context.SaveChangesAsync();
        }
    }
}
