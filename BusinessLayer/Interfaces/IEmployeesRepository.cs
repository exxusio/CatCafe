using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employees>> GetAll(bool includePositions = false);
        Task<Employees> GetById(int ID, bool includePosition = false);
        Task Save(Employees employee);
        Task Delete(Employees employee);
    }
}
