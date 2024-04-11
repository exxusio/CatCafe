using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class EmployeesService
    {
        private DataManager _dataManager;
        private PositionsService _positionsService;

        public EmployeesService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _positionsService = new PositionsService(dataManager);
        }

        public async Task<ICollection<ViewEmployees>> GetList()
        {
            var employees = await _dataManager.employees.GetAll();
            List<ViewEmployees> employeesList = new List<ViewEmployees>();

            foreach (var item in employees)
                employeesList.Add(await GetViewById(item.ID));
            
            return employeesList;
        }

        public async Task<ViewEmployees> GetViewById(int ID)
        {
            var employee = await _dataManager.employees.GetById(ID, true);

            ViewPositions position = new ViewPositions();
            position = await _positionsService.GetViewById(employee.position.ID);

            return new ViewEmployees() 
            { 
                ID = employee.ID,
                name = employee.name,
                surname = employee.surname,
                about = employee.about,
                photography = employee.photography,
                salary = employee.salary,
                hireDate = employee.hireDate,
                position = position 
            };
        }

        public async Task<EditEmployees> GetEditById(int ID = 0)
        {
            var employee = await _dataManager.employees.GetById(ID);

            return new EditEmployees()
            {
                ID = employee.ID,
                name = employee.name,
                surname = employee.surname,
                positionID = employee.positionID,
                about = employee.about,
                photography = employee.photography,
                salary = employee.salary,
                hireDate = employee.hireDate
            };
        }

        public async Task<ViewEmployees> SaveEdit(EditEmployees editEmployee)
        {
            Employees employee;

            if (editEmployee.ID != 0)
                employee = await _dataManager.employees.GetById(editEmployee.ID);
            else
                employee = new Employees();
            
            employee.name = editEmployee.name;
            employee.surname = editEmployee.surname;
            employee.positionID = editEmployee.positionID;
            employee.about = editEmployee.about;
            employee.photography = editEmployee.photography;
            employee.salary = editEmployee.salary;
            employee.hireDate = editEmployee.hireDate;

            await _dataManager.employees.Save(employee);

            return await GetViewById(employee.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.employees.Delete(await _dataManager.employees.GetById(ID));
        }

        public async Task DeleteView(ViewEmployees employee)
        {
            await _dataManager.employees.Delete(await _dataManager.employees.GetById(employee.ID));
        }
    }
}
