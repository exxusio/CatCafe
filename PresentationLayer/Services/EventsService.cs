using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class EventsService
    {
        private DataManager _dataManager;

        public EventsService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<ICollection<ViewEvents>> GetList()
        {
            var _events = await _dataManager.events.GetAll();
            List<ViewEvents> _eventsList = new List<ViewEvents>();

            foreach (var item in _events)
                _eventsList.Add(await GetViewById(item.ID));
            
            return _eventsList;
        }

        public async Task<ViewEvents> GetViewById(int ID)
        {
            var _event = await _dataManager.events.GetById(ID);

            return new ViewEvents()
            {
                ID = _event.ID,
                name = _event.name,
                description = _event.description,
                photography = _event.photography,
                date = _event.date,
                time = _event.time
            };
        }

        public async Task<EditEvents> GetEditById(int ID)
        {
            var _event = await _dataManager.events.GetById(ID);

            return new EditEvents()
            {
                ID = _event.ID,
                name = _event.name,
                description = _event.description,
                photography = _event.photography,
                date = _event.date,
                time = _event.time
            };
        }

        public async Task<ViewEvents> SaveEdit(EditEvents editEvent)
        {
            Events _event;
            
            if (editEvent.ID != 0)
                _event = await _dataManager.events.GetById(editEvent.ID);
            else
                _event = new Events();
            
            _event.name = editEvent.name;
            _event.description = editEvent.description;
            _event.photography = editEvent.photography;
            _event.date = editEvent.date;
            _event.time = editEvent.time;

            await _dataManager.events.Save(_event);
            
            return await GetViewById(_event.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.events.Delete(await _dataManager.events.GetById(ID));
        }

        public async Task DeleteView(ViewEvents _event)
        {
            await _dataManager.events.Delete(await _dataManager.events.GetById(_event.ID));
        }
    }
}
