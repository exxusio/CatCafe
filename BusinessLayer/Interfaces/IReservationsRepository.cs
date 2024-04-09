using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IReservationsRepository
    {
        Task<IEnumerable<Reservations>> GetAll();
        Task<Reservations> GetById(int ID);
        Task Save(Reservations reservation);
        Task Delete(Reservations reservation);
    }
}
