using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class ReservationsService
    {
        private DataManager _dataManager;
        private ReservationCatsService _reservationCatsService;
        private ReservationTablesService _reservationTablesService;

        public ReservationsService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _reservationCatsService = new ReservationCatsService(dataManager);
            _reservationTablesService = new ReservationTablesService(dataManager);
        }

        public async Task<ICollection<ViewReservations>> GetList()
        {
            var reservations = await _dataManager.reservations.GetAll();
            List<ViewReservations> reservationsList = new List<ViewReservations>();
            
            foreach (var item in reservations)
                reservationsList.Add(await GetViewById(item.ID));
            
            return reservationsList;
        }

        public async Task<ViewReservations> GetViewById(int ID)
        {
            var reservation = await _dataManager.reservations.GetById(ID, true, true);
            ICollection<ViewCats> catsList = new List<ViewCats>();
            ICollection<ViewTables> tablesList = new List<ViewTables>();

            foreach (var item in reservation.reservationCats)
                catsList.Add((await _reservationCatsService.GetViewById(item.ID)).cat);
            
            foreach (var item in reservation.reservationTables)
                tablesList.Add((await _reservationTablesService.GetViewById(item.ID)).table);
            
            return new ViewReservations() 
            { 
                ID = reservation.ID,
                visitorID = reservation.visitorID,
                date = reservation.date,
                time = reservation.time,
                cats = catsList, 
                tables = tablesList 
            };
        }

        public async Task<EditReservations?> GetEditById(int ID = 0)
        {
            var reservation = await _dataManager.reservations.GetById(ID);

            if (reservation != null)
            {
                return new EditReservations()
                {
                    ID = reservation.ID,
                    visitorID = reservation.visitorID,
                    date = reservation.date,
                    time = reservation.time
                };
            }
            return null;
        }

        public async Task<ViewReservations> SaveEdit(EditReservations editReservation)
        {
            Reservations reservation;
            
            if (editReservation.ID != 0)
                reservation = await _dataManager.reservations.GetById(editReservation.ID);
            else
                reservation = new Reservations();
            
            reservation.visitorID = editReservation.visitorID;
            reservation.date = editReservation.date;
            reservation.time = editReservation.time;

            await _dataManager.reservations.Save(reservation);

            return await GetViewById(reservation.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.reservations.Delete(await _dataManager.reservations.GetById(ID));
        }

        public async Task DeleteView(ViewReservations reservation)
        {
            await _dataManager.reservations.Delete(await _dataManager.reservations.GetById(reservation.ID));
        }
    }
}
