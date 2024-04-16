using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class ReservationCatsService
    {
        private DataManager _dataManager;
        private CatsService _catsService;

        public ReservationCatsService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _catsService = new CatsService(dataManager);
        }

        public async Task<ICollection<ViewReservationCats>> GetList()
        {
            var reservationCats = await _dataManager.reservationCats.GetAll();
            List<ViewReservationCats> reservationCatsList = new List<ViewReservationCats>();
            
            foreach (var item in reservationCats)
                reservationCatsList.Add(await GetViewById(item.ID));
            
            return reservationCatsList;
        }

        public async Task<ViewReservationCats> GetViewById(int ID)
        {
            var reservationCat = await _dataManager.reservationCats.GetById(ID, true);

            ViewCats cat = new ViewCats();
            cat = await _catsService.GetViewById(reservationCat.cat.ID);

            return new ViewReservationCats() 
            { 
                ID = reservationCat.ID,
                reservationID = reservationCat.reservationID,
                cat = cat 
            };
        }

        public async Task<EditReservationCats?> GetEditById(int ID = 0)
        {
            var reservationCat = await _dataManager.reservationCats.GetById(ID);

            if (reservationCat != null)
            {
                return new EditReservationCats()
                {
                    ID = reservationCat.ID,
                    reservationID = reservationCat.reservationID,
                    catID = reservationCat.catID
                };
            }
            return null;
        }

        public async Task<ViewReservationCats> SaveEdit(EditReservationCats editReservationCat)
        {
            ReservationCats reservationCat;
            
            if (editReservationCat.ID != 0)
                reservationCat = await _dataManager.reservationCats.GetById(editReservationCat.ID);
            else
                reservationCat = new ReservationCats();
            
            reservationCat.reservationID = editReservationCat.reservationID;
            reservationCat.catID = editReservationCat.catID;

            await _dataManager.reservationCats.Save(reservationCat);

            return await GetViewById(reservationCat.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.reservationCats.Delete(await _dataManager.reservationCats.GetById(ID));
        }

        public async Task DeleteView(ViewReservationCats reservationCat)
        {
            await _dataManager.reservationCats.Delete(await _dataManager.reservationCats.GetById(reservationCat.ID));
        }
    }
}
