using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IReservationTablesRepository
    {
        Task<IEnumerable<ReservationTables>> GetAll(bool includeTables = false, bool includeReservations = false);
        Task<ReservationTables> GetById(int ID, bool includeTable = false, bool includeReservation = false);
        Task Save(ReservationTables reservationTable);
        Task Delete(ReservationTables reservationTable);
    }
}
