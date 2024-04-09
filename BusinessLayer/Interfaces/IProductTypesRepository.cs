using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IProductTypesRepository
    {
        Task<IEnumerable<ProductTypes>> GetAll();
        Task<ProductTypes> GetById(int ID);
        Task Save(ProductTypes type);
        Task Delete(ProductTypes type);
    }
}
