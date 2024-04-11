using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ITablesRepository
    {
        Task<IEnumerable<Tables>> GetAll();
        Task<Tables> GetById(int ID);
        Task Save(Tables table);
        Task Delete(Tables table);
    }
}
