using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IBreedsRepository
    {
        Task<IEnumerable<Breeds>> GetAll();
        Task<Breeds> GetById(int ID);
        Task Save(Breeds breed);
        Task Delete(Breeds breed);
    }
}
