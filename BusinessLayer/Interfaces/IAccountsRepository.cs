using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IAccountsRepository
    {
        Task<IEnumerable<Accounts>> GetAll(bool includeVisitors = false);
        Task<Accounts> GetById(int ID, bool includeVisitor = false);
        Task Save(Accounts account);
        Task Delete(Accounts account);
    }
}
