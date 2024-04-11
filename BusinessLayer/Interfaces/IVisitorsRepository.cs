using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IVisitorsRepository
    {
        Task<IEnumerable<Visitors>> GetAll(bool includeOrders = false, bool includeReservations = false);
        Task<Visitors> GetById(int ID, bool includeOrder = false, bool includeReservation = false);
        Task Save(Visitors visitor);
        Task Delete(Visitors visitor);
    }
}
