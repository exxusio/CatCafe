using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IPositionsRepository
    {
        Task<IEnumerable<Positions>> GetAll();
        Task<Positions> GetById(int ID);
        Task Save(Positions position);
        Task Delete(Positions position);
    }
}
