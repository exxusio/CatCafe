using DataAccessLayer.Entities;
using DataAccessLayer;
using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class EventsRepository : IEventsRepository
    {
        private readonly DataBaseContext _context;

        public EventsRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Events>> GetAll()
        {
            return await _context.events.ToListAsync();
        }

        public async Task<Events> GetById(int ID)
        {
            return await _context.events.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task Save(Events _event)
        {
            if (_event.ID == 0)
                _context.events.Add(_event);
            else
                _context.Entry(_event).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Events _event)
        {
            _context.events.Remove(_event);
            await _context.SaveChangesAsync();
        }
    }
}
