using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IReviewsRepository
    {
        Task<IEnumerable<Reviews>> GetAll(bool includeVisitors = false);
        Task<Reviews> GetById(int ID, bool includeVisitor = false);
        Task Save(Reviews review);
        Task Delete(Reviews review);
    }
}
