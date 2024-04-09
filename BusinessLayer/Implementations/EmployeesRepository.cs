using DataAccessLayer.Entities;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly DataBaseContext _context;

        public EmployeesRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employees>> GetAll(bool includePositions = false)
        {
            if (includePositions)
                return await _context.Set<Employees>().Include(x => x.position).AsNoTracking().ToListAsync();
            else
                return await _context.employees.ToListAsync();
        }

        public async Task<Employees> GetById(int ID, bool includePosition = false)
        {
            if (includePosition)
                return await _context.Set<Employees>().Include(x => x.position).AsNoTracking().FirstOrDefaultAsync(x => x.ID == ID);
            else
                return await _context.employees.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task Save(Employees employee)
        {
            if (employee.ID == 0)
                _context.employees.Add(employee);
            else
                _context.Entry(employee).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Employees employee)
        {
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
