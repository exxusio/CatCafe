using BusinessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class ContentsRepository : IContentsRepository
    {
        private readonly DataBaseContext _context;

        public ContentsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contents>> GetAll(bool includeProducts = false, bool includeOrders = false)
        {
            IQueryable<Contents> query = _context.contents;

            if (includeProducts)
                query = query.Include(t => t.product);

            if (includeOrders)
                query = query.Include(t => t.order);

            return await query.ToListAsync();
        }

        public async Task<Contents> GetById(int ID, bool includeProduct = false, bool includeOrder = false)
        {
            IQueryable<Contents> query = _context.contents.Where(t => t.ID == ID);

            if (includeProduct)
                query = query.Include(t => t.product);

            if (includeOrder)
                query = query.Include(t => t.order);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Save(Contents content)
        {
            if (content.ID == 0)
                _context.contents.Add(content);
            else
                _context.Entry(content).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Contents content)
        {
            _context.contents.Remove(content);
            await _context.SaveChangesAsync();
        }
    }
}
