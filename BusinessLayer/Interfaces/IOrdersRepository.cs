using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Orders>> GetAll(bool includeContents = false, bool includeTables = false);
        Task<Orders> GetById(int ID, bool includeContent = false, bool includeTable = false);
        Task Save(Orders order);
        Task Delete(Orders order);
    }
}
