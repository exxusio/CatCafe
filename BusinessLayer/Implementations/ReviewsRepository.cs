using DataAccessLayer.Entities;
using DataAccessLayer;
using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly DataBaseContext _context;

        public ReviewsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reviews>> GetAll(bool includeVisitors = false)
        {
            if (includeVisitors)
                return await _context.Set<Reviews>().Include(x => x.visitor).AsNoTracking().ToListAsync();
            else
                return await _context.reviews.ToListAsync();
        }

        public async Task<Reviews> GetById(int ID, bool includeVisitor = false)
        {
            if (includeVisitor)
                return await _context.Set<Reviews>().Include(x => x.visitor).AsNoTracking().FirstOrDefaultAsync(x => x.ID == ID);
            else
                return await _context.reviews.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task Save(Reviews review)
        {
            if (review.ID == 0)
                _context.reviews.Add(review);
            else
                _context.Entry(review).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Reviews review)
        {
            _context.reviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}
