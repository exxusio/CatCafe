using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class CatsService
    {
        private DataManager _dataManager;
        private BreedsService _breedsService;

        public CatsService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _breedsService = new BreedsService(dataManager);
        }

        public async Task<ICollection<ViewCats>> GetList()
        {
            var cats = await _dataManager.cats.GetAll();
            List<ViewCats> catsList = new List<ViewCats>();

            foreach (var item in cats)
                catsList.Add(await GetViewById(item.ID));
            
            return catsList;
        }

        public async Task<ViewCats> GetViewById(int ID)
        {
            var cat = await _dataManager.cats.GetById(ID, true);

            ViewBreeds breed = new ViewBreeds();
            breed = await _breedsService.GetViewById(cat.breed.ID);

            return new ViewCats() 
            { 
                ID = cat.ID,
                name = cat.name,
                photography = cat.photography,
                dateOfBirth = cat.dateOfBirth,
                descriptionCharacter = cat.descriptionCharacter,
                breed = breed 
            };
        }

        public async Task<EditCats?> GetEditById(int ID = 0)
        {
            var cat = await _dataManager.cats.GetById(ID);

            if (cat != null)
            {
                return new EditCats()
                {
                    ID = cat.ID,
                    name = cat.name,
                    breedID = cat.breedID,
                    photography = cat.photography,
                    dateOfBirth = cat.dateOfBirth,
                    descriptionCharacter = cat.descriptionCharacter
                };
            }
            return null;
        }

        public async Task<ViewCats> SaveEdit(EditCats editCat)
        {
            Cats cat;
            
            if (editCat.ID != 0)
                cat = await _dataManager.cats.GetById(editCat.ID);
            else
                cat = new Cats();
            
            cat.name = editCat.name;
            cat.breedID = editCat.breedID;
            cat.photography = editCat.photography;
            cat.dateOfBirth = editCat.dateOfBirth;
            cat.descriptionCharacter = editCat.descriptionCharacter;

            await _dataManager.cats.Save(cat);

            return await GetViewById(cat.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.cats.Delete(await _dataManager.cats.GetById(ID));
        }

        public async Task DeleteView(ViewCats cat)
        {
            await _dataManager.cats.Delete(await _dataManager.cats.GetById(cat.ID));
        }
    }
}
