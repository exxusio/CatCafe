using BusinessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class ProductTypesRepository : IProductTypesRepository
    {
        private readonly DataBaseContext _context;

        public ProductTypesRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductTypes>> GetAll()
        {
            return await _context.types.ToListAsync();
        }

        public async Task<ProductTypes> GetById(int ID)
        {
            return await _context.types.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task Save(ProductTypes type)
        {
            if (type.ID == 0)
                _context.types.Add(type);
            else
                _context.Entry(type).State = EntityState.Modified;


            await _context.SaveChangesAsync();
        }

        public async Task Delete(ProductTypes type)
        {
            _context.types.Remove(type);
            await _context.SaveChangesAsync();
        }
    }
}
