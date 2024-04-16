using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class AccountsService
    {
        private DataManager _dataManager;
        private VisitorsService _visitorsService;

        public AccountsService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _visitorsService = new VisitorsService(dataManager);
        }

        public async Task<ICollection<ViewAccounts>> GetList()
        {
            var accounts = await _dataManager.accounts.GetAll();
            List<ViewAccounts> accountsList = new List<ViewAccounts>();

            foreach (var item in accounts)
                accountsList.Add(await GetViewById(item.ID));

            return accountsList;
        }

        public async Task<ViewAccounts> GetViewById(int ID)
        {
            var account = await _dataManager.accounts.GetById(ID, true);

            ViewVisitors visitor = new ViewVisitors();
            visitor = await _visitorsService.GetViewById(account.visitor.ID);

            return new ViewAccounts()
            {
                ID = account.ID,
                login = account.login,
                password = account.password,
                registrationDate = account.registrationDate,
                visitor = visitor
            };
        }

        public async Task<EditAccounts?> GetEditById(int ID = 0)
        {
            var account = await _dataManager.accounts.GetById(ID);

            if (account != null)
            {
                return new EditAccounts()
                {
                    ID = account.ID,
                    visitorID = account.visitorID,
                    login = account.login,
                    password = account.password,
                    registrationDate = account.registrationDate
                };
            }
            return null;
        }

        public async Task<ViewAccounts> SaveEdit(EditAccounts editAccount)
        {
            Accounts account;

            if (editAccount.ID != 0)
                account = await _dataManager.accounts.GetById(editAccount.ID);
            else
                account = new Accounts();

            account.visitorID = editAccount.visitorID;
            account.login = editAccount.login;
            account.password = editAccount.password;
            account.registrationDate = editAccount.registrationDate;

            await _dataManager.accounts.Save(account);

            return await GetViewById(account.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.accounts.Delete(await _dataManager.accounts.GetById(ID));
        }

        public async Task DeleteView(ViewAccounts account)
        {
            await _dataManager.accounts.Delete(await _dataManager.accounts.GetById(account.ID));
        }
    }
}
