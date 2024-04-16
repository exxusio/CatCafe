using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class ContentsService
    {
        private DataManager _dataManager;
        private ProductsService _productsService;

        public ContentsService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _productsService = new ProductsService(dataManager);
        }

        public async Task<ICollection<ViewContents>> GetList()
        {
            var contents = await _dataManager.contents.GetAll();
            List<ViewContents> contentsList = new List<ViewContents>();

            foreach (var item in contents)
                contentsList.Add(await GetViewById(item.ID));

            return contentsList;
        }

        public async Task<ViewContents> GetViewById(int ID)
        {
            var content = await _dataManager.contents.GetById(ID, true);

            ViewProducts product = new ViewProducts();
            product = await _productsService.GetViewById(content.product.ID);

            return new ViewContents()
            {
                ID = content.ID,
                orderID = content.orderID,
                product = product,
                quantity = content.quantity
            };
        }

        public async Task<EditContents?> GetEditById(int ID = 0)
        {
            var content = await _dataManager.contents.GetById(ID);

            if (content != null)
            {
                return new EditContents()
                {
                    ID = content.ID,
                    orderID = content.orderID,
                    productID = content.productID,
                    quantity = content.quantity
                };
            }
            return null;
        }

        public async Task<ViewContents> SaveEdit(EditContents editContent)
        {
            Contents content;

            if (editContent.ID != 0)
                content = await _dataManager.contents.GetById(editContent.ID);
            else
                content = new Contents();

            content.orderID = editContent.orderID;
            content.productID = editContent.productID;
            content.quantity = editContent.quantity;

            await _dataManager.contents.Save(content);

            return await GetViewById(content.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.contents.Delete(await _dataManager.contents.GetById(ID));
        }

        public async Task DeleteView(ViewContents content)
        {
            await _dataManager.contents.Delete(await _dataManager.contents.GetById(content.ID));
        }
    }
}
