using DataAccessLayer.Entities;
using DataAccessLayer;
using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class PositionsRepository : IPositionsRepository
    {
        private readonly DataBaseContext _context;

        public PositionsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Positions>> GetAll()
        {
            return await _context.positions.ToListAsync();
        }

        public async Task<Positions> GetById(int ID)
        {
            return await _context.positions.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task Save(Positions position)
        {
            if (position.ID == 0)
                _context.positions.Add(position);
            else
                _context.Entry(position).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Positions position)
        {
            _context.positions.Remove(position);
            await _context.SaveChangesAsync();
        }
    }
}
