using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class VisitorsService
    {
        private DataManager _dataManager;
        private OrdersService _ordersService;
        private ReservationsService _reservationsService;

        public VisitorsService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _ordersService = new OrdersService(dataManager);
            _reservationsService = new ReservationsService(dataManager);
        }

        public async Task<ICollection<ViewVisitors>> GetList()
        {
            var visitors = await _dataManager.visitors.GetAll();
            List<ViewVisitors> visitorsList = new List<ViewVisitors>();

            foreach (var item in visitors)
                visitorsList.Add(await GetViewById(item.ID));

            return visitorsList;
        }

        public async Task<ViewVisitors> GetViewById(int ID)
        {
            var visitor = await _dataManager.visitors.GetById(ID, true, true);

            ICollection<ViewOrders> ordersList = new List<ViewOrders>();
            ICollection<ViewReservations> reservationsList = new List<ViewReservations>();

            foreach (var item in visitor.orders)
                ordersList.Add(await _ordersService.GetViewById(item.ID));

            foreach (var item in visitor.reservations)
                reservationsList.Add(await _reservationsService.GetViewById(item.ID));

            return new ViewVisitors()
            {
                ID = visitor.ID,
                name = visitor.name,
                surname = visitor.surname,
                phoneNumber = visitor.phoneNumber,
                emailAddress = visitor.emailAddress,
                dateOfBirth = visitor.dateOfBirth,
                orders = ordersList,
                reservations = reservationsList
            };
        }

        public async Task<EditVisitors?> GetEditById(int ID = 0)
        {
            var visitor = await _dataManager.visitors.GetById(ID);

            if (visitor != null)
            {
                return new EditVisitors()
                {
                    ID = visitor.ID,
                    name = visitor.name,
                    surname = visitor.surname,
                    phoneNumber = visitor.phoneNumber,
                    emailAddress = visitor.emailAddress,
                    dateOfBirth = visitor.dateOfBirth
                };
            }
            return null;
        }

        public async Task<ViewVisitors> SaveEdit(EditVisitors editVisitor)
        {
            Visitors visitor;

            if (editVisitor.ID != 0)
                visitor = await _dataManager.visitors.GetById(editVisitor.ID);
            else
                visitor = new Visitors();

            visitor.name = editVisitor.name;
            visitor.surname = editVisitor.surname;
            visitor.phoneNumber = editVisitor.phoneNumber;
            visitor.emailAddress = editVisitor.emailAddress;
            visitor.dateOfBirth = editVisitor.dateOfBirth;

            await _dataManager.visitors.Save(visitor);

            return await GetViewById(visitor.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.visitors.Delete(await _dataManager.visitors.GetById(ID));
        }

        public async Task DeleteView(ViewVisitors visitor)
        {
            await _dataManager.visitors.Delete(await _dataManager.visitors.GetById(visitor.ID));
        }
    }
}
