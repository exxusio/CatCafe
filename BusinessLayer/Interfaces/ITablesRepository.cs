using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ITablesRepository
    {
        Task<IEnumerable<Tables>> GetAll(bool includeReservations = false, bool includeOrders = false);
        Task<Tables> GetById(int ID, bool includeReservation = false, bool includeOrder = false);
        Task Save(Tables table);
        Task Delete(Tables table);
    }
}
