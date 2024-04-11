using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class ReservationTablesService
    {
        private DataManager _dataManager;
        private TablesService _tablesService;

        public ReservationTablesService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _tablesService = new TablesService(dataManager);
        }

        public async Task<ICollection<ViewReservationTables>> GetList()
        {
            var reservationTables = await _dataManager.reservationTables.GetAll();
            List<ViewReservationTables> reservationTablesList = new List<ViewReservationTables>();
            
            foreach (var item in reservationTables)
                reservationTablesList.Add(await GetViewById(item.ID));
            
            return reservationTablesList;
        }

        public async Task<ViewReservationTables> GetViewById(int ID)
        {
            var reservationTable = await _dataManager.reservationTables.GetById(ID, true);

            ViewTables table = new ViewTables();
            table = await _tablesService.GetViewById(reservationTable.table.ID);

            return new ViewReservationTables() 
            { 
                ID = reservationTable.ID,
                reservationID = reservationTable.reservationID,
                table = table 
            };
        }

        public async Task<EditReservationTables> GetEditById(int ID = 0)
        {
            var reservationTable = await _dataManager.reservationTables.GetById(ID);

            return new EditReservationTables()
            {
                ID = reservationTable.ID,
                reservationID = reservationTable.reservationID,
                tableID = reservationTable.tableID
            };
        }

        public async Task<ViewReservationTables> SaveEdit(EditReservationTables editReservationTable)
        {
            ReservationTables reservationTable;
            
            if (editReservationTable.ID != 0)
                reservationTable = await _dataManager.reservationTables.GetById(editReservationTable.ID);
            else
                reservationTable = new ReservationTables();
            
            reservationTable.reservationID = editReservationTable.reservationID;
            reservationTable.tableID = editReservationTable.tableID;

            await _dataManager.reservationTables.Save(reservationTable);

            return await GetViewById(reservationTable.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.reservationTables.Delete(await _dataManager.reservationTables.GetById(ID));
        }

        public async Task DeleteView(ViewReservationTables reservationTable)
        {
            await _dataManager.reservationTables.Delete(await _dataManager.reservationTables.GetById(reservationTable.ID));
        }
    }
}
