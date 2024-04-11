using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IReservationTablesRepository
    {
        Task<IEnumerable<ReservationTables>> GetAll(bool includeTables = false);
        Task<ReservationTables> GetById(int ID, bool includeTable = false);
        Task Save(ReservationTables reservationTable);
        Task Delete(ReservationTables reservationTable);
    }
}
