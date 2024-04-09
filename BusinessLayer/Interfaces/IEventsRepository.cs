using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Events>> GetAll();
        Task<Events> GetById(int ID);
        Task Save(Events _event);
        Task Delete(Events _event);
    }
}
