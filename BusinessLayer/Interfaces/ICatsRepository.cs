using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ICatsRepository
    {
        Task<IEnumerable<Cats>> GetAll(bool includeBreeds = false);
        Task<Cats> GetById(int ID, bool includeBreed = false);
        Task Save(Cats cat);
        Task Delete(Cats cat);
    }
}
