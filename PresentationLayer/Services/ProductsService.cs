using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class ProductsService
    {
        private DataManager _dataManager;
        private ProductTypesService _productTypesService;

        public ProductsService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _productTypesService = new ProductTypesService(dataManager);
        }

        public async Task<ICollection<ViewProducts>> GetList()
        {
            var products = await _dataManager.products.GetAll();
            List<ViewProducts> productsList = new List<ViewProducts>();

            foreach (var item in products)
                productsList.Add(await GetViewById(item.ID));

            return productsList;
        }

        public async Task<ViewProducts> GetViewById(int ID)
        {
            var product = await _dataManager.products.GetById(ID, true);

            ViewProductTypes type = new ViewProductTypes();
            type = await _productTypesService.GetViewById(product.type.ID);

            return new ViewProducts()
            {
                ID = product.ID,
                name = product.name,
                description = product.description, 
                photography = product.photography, 
                price = product.price, 
                type = type
            };
        }

        public async Task<EditProducts> GetEditById(int ID = 0)
        {
            var product = await _dataManager.products.GetById(ID);

            return new EditProducts()
            {
                ID = product.ID,
                name = product.name,
                typeID = product.typeID,
                description = product.description,
                photography = product.photography,
                price = product.price
            };
        }

        public async Task<ViewProducts> SaveEdit(EditProducts editProduct)
        {
            Products product;

            if (editProduct.ID != 0)
                product = await _dataManager.products.GetById(editProduct.ID);
            else
                product = new Products();
            
            product.name = editProduct.name;
            product.typeID = editProduct.typeID;
            product.description = editProduct.description;
            product.photography = editProduct.photography;
            product.price = editProduct.price;

            await _dataManager.products.Save(product);

            return await GetViewById(product.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.products.Delete(await _dataManager.products.GetById(ID));
        }

        public async Task DeleteView(ViewProducts product)
        {
            await _dataManager.products.Delete(await _dataManager.products.GetById(product.ID));
        }
    }
}
