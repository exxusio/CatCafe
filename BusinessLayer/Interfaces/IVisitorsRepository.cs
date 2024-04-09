using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IVisitorsRepository
    {
        Task<IEnumerable<Visitors>> GetAll(bool includeAccounts = false, bool includeReviews = false, bool includeOrders = false);
        Task<Visitors> GetById(int ID, bool includeAccount = false, bool includeReviews = false, bool includeOrders = false);
        Task Save(Visitors visitor);
        Task Delete(Visitors visitor);
    }
}
