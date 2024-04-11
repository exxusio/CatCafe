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

        public async Task<IEnumerable<Tables>> GetAll()
        {
            return await _context.tables.ToListAsync();
        }

        public async Task<Tables> GetById(int ID)
        {
            return await _context.tables.Where(t => t.ID == ID).FirstOrDefaultAsync();
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
