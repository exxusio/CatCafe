using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class BreedsService
    {
        private DataManager _dataManager;

        public BreedsService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<ICollection<ViewBreeds>> GetList()
        {
            var breeds = await _dataManager.breeds.GetAll();
            List<ViewBreeds> breedsList = new List<ViewBreeds>();

            foreach (var item in breeds)
                breedsList.Add(await GetViewById(item.ID));
            
            return breedsList;
        }

        public async Task<ViewBreeds> GetViewById(int ID)
        {
            var breed = await _dataManager.breeds.GetById(ID);

            return new ViewBreeds()
            {
                ID = breed.ID,
                name = breed.name,
                description = breed.description
            };
        }

        public async Task<EditBreeds?> GetEditById(int ID)
        {
            var breed = await _dataManager.breeds.GetById(ID);

            if (breed != null)
            {
                return new EditBreeds()
                {
                    ID = breed.ID,
                    name = breed.name,
                    description = breed.description
                };
            }
            return null;
        }

        public async Task<ViewBreeds> SaveEdit(EditBreeds editBreed)
        {
            Breeds breed;

            if (editBreed.ID != 0)
                breed = await _dataManager.breeds.GetById(editBreed.ID);
            else
                breed = new Breeds();
            
            breed.name = editBreed.name;
            breed.description = editBreed.description;

            await _dataManager.breeds.Save(breed);
            
            return await GetViewById(breed.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.breeds.Delete(await _dataManager.breeds.GetById(ID));
        }

        public async Task DeleteView(ViewBreeds breed)
        {
            await _dataManager.breeds.Delete(await _dataManager.breeds.GetById(breed.ID));
        }
    }
}
