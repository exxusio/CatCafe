using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IReservationsRepository
    {
        Task<IEnumerable<Reservations>> GetAll(bool includeCats = false, bool includeTables = false);
        Task<Reservations> GetById(int ID, bool includeCat = false, bool includeTable = false);
        Task Save(Reservations reservation);
        Task Delete(Reservations reservation);
    }
}
