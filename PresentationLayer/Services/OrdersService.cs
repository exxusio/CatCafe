using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class OrdersService
    {
        private DataManager _dataManager;
        private TablesService _tablesService;
        private ContentsService _contentsService;

        public OrdersService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _tablesService = new TablesService(dataManager);
            _contentsService = new ContentsService(dataManager);
        }

        public async Task<ICollection<ViewOrders>> GetList()
        {
            var orders = await _dataManager.orders.GetAll();
            List<ViewOrders> ordersList = new List<ViewOrders>();

            foreach (var item in orders)
                ordersList.Add(await GetViewById(item.ID));

            return ordersList;
        }

        public async Task<ViewOrders> GetViewById(int ID)
        {
            var order = await _dataManager.orders.GetById(ID, true, true);
            ICollection<ViewContents> contentsList = new List<ViewContents>();

            ViewTables table = new ViewTables();
            table = order.table == null ? null : await _tablesService.GetViewById(order.table.ID);

            foreach (var item in order.contents)
                contentsList.Add(await _contentsService.GetViewById(item.ID));

            return new ViewOrders()
            {
                ID = order.ID,
                visitorID = order.visitorID,
                date = order.date,
                time = order.time,
                contents = contentsList,
                table = table
            };
        }

        public async Task<EditOrders?> GetEditById(int ID = 0)
        {
            var order = await _dataManager.orders.GetById(ID);

            if (order != null)
            {
                return new EditOrders()
                {
                    ID = order.ID,
                    visitorID = order.visitorID,
                    tableID = order.tableID,
                    date = order.date,
                    time = order.time
                };
            }
            return null;
        }

        public async Task<ViewOrders> SaveEdit(EditOrders editOrder)
        {
            Orders order;

            if (editOrder.ID != 0)
                order = await _dataManager.orders.GetById(editOrder.ID);
            else
                order = new Orders();

            order.visitorID = editOrder.visitorID;
            order.tableID   = editOrder.tableID;
            order.date = editOrder.date;
            order.time = editOrder.time;

            await _dataManager.orders.Save(order);

            return await GetViewById(order.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.orders.Delete(await _dataManager.orders.GetById(ID));
        }

        public async Task DeleteView(ViewOrders order)
        {
            await _dataManager.orders.Delete(await _dataManager.orders.GetById(order.ID));
        }
    }
}
