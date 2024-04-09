using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataBaseContext _context;

        public ProductsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetAll(bool includeTypes = false)
        {
            if (includeTypes)
                return await _context.Set<Products>().Include(x => x.type).AsNoTracking().ToListAsync();
            else
                return await _context.products.ToListAsync();
        }

        public async Task<Products> GetById(int ID, bool includeType = false)
        {
            if (includeType)
                return await _context.Set<Products>().Include(x => x.type).AsNoTracking().FirstOrDefaultAsync(x => x.ID == ID);
            else
                return await _context.products.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task Save(Products product)
        {
            if (product.ID == 0)
                _context.products.Add(product);
            else
                _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Products product)
        {
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
