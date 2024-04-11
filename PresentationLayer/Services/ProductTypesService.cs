using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class ProductTypesService
    {
        private DataManager _dataManager;

        public ProductTypesService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<ICollection<ViewProductTypes>> GetList()
        {
            var types = await _dataManager.productTypes.GetAll();
            List<ViewProductTypes> typesList = new List<ViewProductTypes>();

            foreach (var item in types)
                typesList.Add(await GetViewById(item.ID));

            return typesList;
        }

        public async Task<ViewProductTypes> GetViewById(int ID)
        {
            ProductTypes type = await _dataManager.productTypes.GetById(ID);

            return new ViewProductTypes()
            {
                ID = type.ID,
                name = type.name
            };
        }

        public async Task<EditProductTypes> GetEditById(int ID)
        {
            var type = await _dataManager.productTypes.GetById(ID);

            return new EditProductTypes()
            {
                ID = type.ID,
                name = type.name
            };
        }

        public async Task<ViewProductTypes> SaveEdit(EditProductTypes editType)
        {
            ProductTypes type;

            if (editType.ID != 0)
                type = await _dataManager.productTypes.GetById(editType.ID);
            else
                type = new ProductTypes();
            
            type.name = editType.name;

            await _dataManager.productTypes.Save(type);

            return await GetViewById(type.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.productTypes.Delete(await _dataManager.productTypes.GetById(ID));
        }

        public async Task DeleteView(ViewProductTypes type)
        {
            await _dataManager.productTypes.Delete(await _dataManager.productTypes.GetById(type.ID));
        }
    }
}
