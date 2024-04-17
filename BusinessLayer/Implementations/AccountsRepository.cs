using BusinessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly DataBaseContext _context;

        public AccountsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Accounts>> GetAll(bool includeVisitors = false)
        {
            if (includeVisitors)
                return await _context.Set<Accounts>().Include(x => x.visitor).AsNoTracking().ToListAsync();
            else
                return await _context.accounts.ToListAsync();
        }

        public async Task<Accounts> GetById(int ID, bool includeVisitor = false)
        {
            if (includeVisitor)
                return await _context.Set<Accounts>().Include(x => x.visitor).AsNoTracking().FirstOrDefaultAsync(x => Convert.ToInt32(x.Id) == ID);
            else
                return await _context.accounts.FirstOrDefaultAsync(x => x.Id == ID);
        }

        public async Task Save(Accounts account)
        {
            if (account.Id == 0)
                _context.accounts.Add(account);
            else
                _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Accounts account)
        {
            _context.accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }
}
