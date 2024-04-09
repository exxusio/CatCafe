using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Orders>> GetAll(bool includeVisitors = false, bool includeContents = false);
        Task<Orders> GetById(int ID, bool includeVisitor = false, bool includeContent = false);
        Task Save(Orders order);
        Task Delete(Orders order);
    }
}
