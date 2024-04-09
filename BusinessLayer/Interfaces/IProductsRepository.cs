using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Products>> GetAll(bool includeTypes = false);
        Task<Products> GetById(int ID, bool includeType = false);
        Task Save(Products product);
        Task Delete(Products product);
    }
}
