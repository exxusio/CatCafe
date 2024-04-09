using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IContentsRepository
    {
        Task<IEnumerable<Contents>> GetAll(bool includeProducts = false, bool includeOrders = false);
        Task<Contents> GetById(int ID, bool includeProduct = false, bool includeOrder = false);
        Task Save(Contents content);
        Task Delete(Contents content);
    }
}
