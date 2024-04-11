using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class PositionsService
    {
        private DataManager _dataManager;

        public PositionsService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<ICollection<ViewPositions>> GetList()
        {
            var positions = await _dataManager.positions.GetAll();
            List<ViewPositions> positionsList = new List<ViewPositions>();

            foreach (var item in positions)
                positionsList.Add(await GetViewById(item.ID));
            
            return positionsList;
        }

        public async Task<ViewPositions> GetViewById(int ID)
        {
            var position = await _dataManager.positions.GetById(ID);

            return new ViewPositions()
            {
                ID = position.ID,
                description = position.description
            };
        }

        public async Task<EditPositions> GetEditById(int ID)
        {
            var position = await _dataManager.positions.GetById(ID);

            return new EditPositions()
            {
                ID = position.ID,
                description = position.description
            };
        }

        public async Task<ViewPositions> SaveEdit(EditPositions editPosition)
        {
            Positions position;
            
            if (editPosition.ID != 0)
                position = await _dataManager.positions.GetById(editPosition.ID);
            else
                position = new Positions();
            
            position.description = editPosition.description;

            await _dataManager.positions.Save(position);

            return await GetViewById(position.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.positions.Delete(await _dataManager.positions.GetById(ID));
        }

        public async Task DeleteView(ViewPositions position)
        {
            await _dataManager.positions.Delete(await _dataManager.positions.GetById(position.ID));
        }
    }
}
