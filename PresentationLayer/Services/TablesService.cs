using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class TablesService
    {
        private DataManager _dataManager;

        public TablesService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<ICollection<ViewTables>> GetList()
        {
            var tables = await _dataManager.tables.GetAll();
            List<ViewTables> tablesList = new List<ViewTables>();
            
            foreach (var item in tables)
                tablesList.Add(await GetViewById(item.ID));
            
            return tablesList;
        }

        public async Task<ViewTables> GetViewById(int ID)
        {
            var table = await _dataManager.tables.GetById(ID);

            return new ViewTables()
            {
                ID = table.ID,
                number = table.number,
                capacity = table.capacity
            };
        }

        public async Task<EditTables> GetEditById(int ID)
        {
            var table = await _dataManager.tables.GetById(ID);

            return new EditTables()
            {
                ID = table.ID,
                number = table.number,
                capacity = table.capacity
            };
        }

        public async Task<ViewTables> SaveEdit(EditTables editTable)
        {
            Tables table;
            
            if (editTable.ID != 0)
                table = await _dataManager.tables.GetById(editTable.ID);
            else
                table = new Tables();
            
            table.number = editTable.number;
            table.capacity = editTable.capacity;

            await _dataManager.tables.Save(table);
            
            return await GetViewById(table.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.tables.Delete(await _dataManager.tables.GetById(ID));
        }

        public async Task DeleteView(ViewTables table)
        {
            await _dataManager.tables.Delete(await _dataManager.tables.GetById(table.ID));
        }
    }
}
