using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer;
using BusinessLayer;
using Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Entities;
using System.Security.Claims;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;
        private UserManager<Accounts> _userManager;
        private SignInManager<Accounts> _signInManager;

        public AdminPanelController(DataManager dataManager, UserManager<Accounts> userManager, SignInManager<Accounts> signInManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
            _userManager = userManager;
            _signInManager = signInManager;
        }



        #region Products
        [HttpGet]
        public async Task<IActionResult> ViewProducts()
        {
            return Json(await _servicesManager.products.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewProductsById(int id)
        {
            if (id > 0)
            {
                var product = await _servicesManager.products.GetEditById(id);
                if (product == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.products.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts(string name, int typeID, string description, IFormFile photography, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description) || photography == null)
                return BadRequest("Не все обязательные поля заполнены");

            if (price <= 0 || price > 100 || typeID <= 0)
                return BadRequest("Некоторые данные неккоректны");

            var type = await _servicesManager.productTypes.GetEditById(typeID);
            if (type == null)
                return UnprocessableEntity("Неправильный вторичный ключ");

            await _servicesManager.products.SaveEdit(
                   new EditProducts()
                   {
                       name = name,
                       typeID = typeID,
                       description = description,
                       photography = await Utils.ConvertImageToBase64(photography),
                       price = price
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditProducts(int id, string name, int typeID, string description, IFormFile photography, decimal price)
        {
            var product = await _servicesManager.products.GetEditById(id);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
                return BadRequest(new { Message = "Не все обязательные поля заполнены", Values = Json(await _servicesManager.products.GetList()) });

            if (price <= 0 || price > 100 || typeID <= 0)
                return BadRequest(new { Message = "Некоторые данные неккоректны", Values = Json(await _servicesManager.products.GetList()) });

            var type = await _servicesManager.productTypes.GetEditById(typeID);
            if (type == null)
                return UnprocessableEntity(new { Message = "Неправильный вторичный ключ", Values = Json(await _servicesManager.products.GetList()) });

            byte[] photo = photography == null ? product.photography : await Utils.ConvertImageToBase64(photography);

            product = new EditProducts()
            {
                ID = id,
                name = name,
                typeID = typeID,
                description = description,
                photography = photo,
                price = price
            };

            await _servicesManager.products.SaveEdit(product);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.products.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            if (id > 0)
            {
                var product = await _servicesManager.products.GetEditById(id);
                if (product == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.products.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Types
        [HttpGet]
        public async Task<IActionResult> ViewTypes()
        {
            return Json(await _servicesManager.productTypes.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewTypeById(int id)
        {
            if (id > 0)
            {
                var type = await _servicesManager.productTypes.GetEditById(id);
                if (type == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.productTypes.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddTypes(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Не все обязательные поля заполнены");

            await _servicesManager.productTypes.SaveEdit(
                   new EditProductTypes()
                   {
                       name = name
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditTypes(int id, string name)
        {
            var type = await _servicesManager.productTypes.GetEditById(id);

            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(new { Message = "Не все обязательные поля заполнены", Values = Json(await _servicesManager.productTypes.GetList()) });

            type = new EditProductTypes()
            {
                ID = id,
                name = name
            };

            await _servicesManager.productTypes.SaveEdit(type);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.productTypes.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTypes(int id)
        {
            if (id > 0)
            {
                var type = await _servicesManager.productTypes.GetEditById(id);
                if (type == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.productTypes.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Cats
        [HttpGet]
        public async Task<IActionResult> ViewCats()
        {
            return Json(await _servicesManager.cats.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewCatsById(int id)
        {
            if (id > 0)
            {
                var cat = await _servicesManager.cats.GetEditById(id);
                if (cat == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.cats.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddCats(string name, int breedID, IFormFile photography, string descriptionCharacter, DateOnly dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(descriptionCharacter) || photography == null || dateOfBirth == new DateOnly(1, 1, 1))
                return BadRequest("Не все обязательные поля заполнены");

            if (breedID <= 0)
                return BadRequest("Некоторые данные неккоректны");

            var breed = await _servicesManager.breeds.GetEditById(breedID);
            if (breed == null)
                return UnprocessableEntity("Неправильный вторичный ключ");

            await _servicesManager.cats.SaveEdit(
                   new EditCats()
                   {
                       name = name,
                       breedID = breedID,
                       photography = await Utils.ConvertImageToBase64(photography),
                       descriptionCharacter = descriptionCharacter,
                       dateOfBirth = dateOfBirth
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditCats(int id, string name, int breedID, IFormFile photography, string descriptionCharacter, DateOnly dateOfBirth)
        {
            var cat = await _servicesManager.cats.GetEditById(id);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(descriptionCharacter))
                return BadRequest(new { Message = "Не все обязательные поля заполнены", Values = Json(await _servicesManager.cats.GetList()) });

            if (breedID <= 0)
                return BadRequest(new { Message = "Некоторые данные неккоректны", Values = Json(await _servicesManager.cats.GetList()) });

            var breed = await _servicesManager.breeds.GetEditById(breedID);
            if (breed == null)
                return UnprocessableEntity(new { Message = "Неправильный вторичный ключ", Values = Json(await _servicesManager.cats.GetList()) });

            byte[] photo = photography == null ? cat.photography : await Utils.ConvertImageToBase64(photography);

            cat = new EditCats()
            {
                ID = id,
                name = name,
                breedID = breedID,
                photography = photo,
                descriptionCharacter = descriptionCharacter,
                dateOfBirth = dateOfBirth
            };

            await _servicesManager.cats.SaveEdit(cat);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.cats.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCats(int id)
        {
            if (id > 0)
            {
                var cat = await _servicesManager.cats.GetEditById(id);
                if (cat == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.cats.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Breeds
        [HttpGet]
        public async Task<IActionResult> ViewBreeds()
        {
            return Json(await _servicesManager.breeds.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewBreedsById(int id)
        {
            if (id > 0)
            {
                var breed = await _servicesManager.breeds.GetEditById(id);
                if (breed == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.breeds.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddBreeds(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
                return BadRequest("Не все обязательные поля заполнены");

            await _servicesManager.breeds.SaveEdit(
                   new EditBreeds()
                   {
                       name = name,
                       description = description
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditBreeds(int id, string name, string description)
        {
            var breed = await _servicesManager.breeds.GetEditById(id);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
                return BadRequest(new { Message = "Не все обязательные поля заполнены", Values = Json(await _servicesManager.breeds.GetList()) });

            breed = new EditBreeds()
            {
                ID = id,
                name = name,
                description = description
            };

            await _servicesManager.breeds.SaveEdit(breed);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.breeds.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBreeds(int id)
        {
            if (id > 0)
            {
                var breed = await _servicesManager.breeds.GetEditById(id);
                if (breed == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.breeds.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Events
        [HttpGet]
        public async Task<IActionResult> ViewEvents()
        {
            return Json(await _servicesManager.events.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewEventsById(int id)
        {
            if (id > 0)
            {
                var _event = await _servicesManager.events.GetEditById(id);
                if (_event == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.events.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddEvents(string name, string description, IFormFile photography, DateOnly date, TimeOnly time)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description) || photography == null || date == new DateOnly(1,1,1) || time == new TimeOnly(0,0))
                return BadRequest("Не все обязательные поля заполнены");

            await _servicesManager.events.SaveEdit(
                   new EditEvents()
                   {
                       name = name,
                       description = description,
                       photography = await Utils.ConvertImageToBase64(photography),
                       date = date,
                       time = time
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditEvents(int id, string name, string description, IFormFile photography, DateOnly date, TimeOnly time)
        {
            var _event = await _servicesManager.events.GetEditById(id);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description) || date == new DateOnly(1, 1, 1))
                return BadRequest(new { Message = "Не все обязательные поля заполнены", Values = Json(await _servicesManager.events.GetList()) });

            byte[] photo = photography == null ? _event.photography : await Utils.ConvertImageToBase64(photography);

            _event = new EditEvents()
            {
                ID = id,
                name = name,
                description = description,
                photography = photo,
                date = date,
                time = time
            };

            await _servicesManager.events.SaveEdit(_event);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.events.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEvents(int id)
        {
            if (id > 0)
            {
                var _event = await _servicesManager.events.GetEditById(id);
                if (_event == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.events.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Employees
        [HttpGet]
        public async Task<IActionResult> ViewEmployees()
        {
            return Json(await _servicesManager.employees.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewEmployeesById(int id)
        {
            if (id > 0)
            {
                var employee = await _servicesManager.employees.GetEditById(id);
                if (employee == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.employees.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployees(string name, string surname, int positionID, string about, IFormFile photography, decimal salary, DateOnly hireDate)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(about) || photography == null || hireDate == new DateOnly(1,1,1))
                return BadRequest("Не все обязательные поля заполнены");

            if (salary <= 0 || positionID <= 0)
                return BadRequest("Некоторые данные неккоректны");

            var position = await _servicesManager.positions.GetEditById(positionID);
            if (position == null)
                return UnprocessableEntity("Неправильный вторичный ключ");

            await _servicesManager.employees.SaveEdit(
                   new EditEmployees()
                   {
                       name = name,
                       surname = surname,
                       positionID = positionID,
                       about = about,
                       photography = await Utils.ConvertImageToBase64(photography),
                       salary = salary,
                       hireDate = hireDate
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditEmployees(int id, string name, string surname, int positionID, string about, IFormFile photography, decimal salary, DateOnly hireDate)
        {
            var employee = await _servicesManager.employees.GetEditById(id);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(about) || hireDate == new DateOnly(1, 1, 1))
                return BadRequest(new { Message = "Не все обязательные поля заполнены", Values = Json(await _servicesManager.employees.GetList()) });

            if (salary <= 0 || positionID <= 0)
                return BadRequest(new { Message = "Некоторые данные неккоректны", Values = Json(await _servicesManager.employees.GetList()) });

            var position = await _servicesManager.positions.GetEditById(positionID);
            if (position == null)
                return UnprocessableEntity(new { Message = "Неправильный вторичный ключ", Values = Json(await _servicesManager.employees.GetList()) });

            byte[] photo = photography == null ? employee.photography : await Utils.ConvertImageToBase64(photography);

            employee = new EditEmployees()
            {
                ID = id,
                name = name,
                surname = surname,
                positionID = positionID,
                about = about,
                photography = photo,
                salary = salary,
                hireDate = hireDate
            };

            await _servicesManager.employees.SaveEdit(employee);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.employees.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            if (id > 0)
            {
                var employee = await _servicesManager.employees.GetEditById(id);
                if (employee == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.employees.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Positions
        [HttpGet]
        public async Task<IActionResult> ViewPositions()
        {
            return Json(await _servicesManager.positions.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewPositionsById(int id)
        {
            if (id > 0)
            {
                var position = await _servicesManager.positions.GetEditById(id);
                if (position == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.positions.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddPositions(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return BadRequest("Не все обязательные поля заполнены");

            await _servicesManager.positions.SaveEdit(
                   new EditPositions()
                   {
                       description = description
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditPositions(int id, string description)
        {
            var position = await _servicesManager.positions.GetEditById(id);

            if (string.IsNullOrWhiteSpace(description))
                return BadRequest(new { Message = "Не все обязательные поля заполнены", Values = Json(await _servicesManager.positions.GetList()) });

            position = new EditPositions()
            {
                ID = id,
                description = description
            };

            await _servicesManager.positions.SaveEdit(position);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.positions.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePositions(int id)
        {
            if (id > 0)
            {
                var position = await _servicesManager.positions.GetEditById(id);
                if (position == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.positions.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Tables
        [HttpGet]
        public async Task<IActionResult> ViewTables()
        {
            return Json(await _servicesManager.tables.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewTablesById(int id)
        {
            if (id > 0)
            {
                var table = await _servicesManager.tables.GetEditById(id);
                if (table == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.tables.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddTables(int number, int capacity)
        {

            if (number <= 0 || capacity <= 0)
                return BadRequest("Некоторые данные неккоректны");

            await _servicesManager.tables.SaveEdit(
                   new EditTables()
                   {
                       number = number,
                       capacity = capacity
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditTables(int id, int number, int capacity)
        {
            var table = await _servicesManager.tables.GetEditById(id);

            if (number <= 0 || capacity <= 0)
                return BadRequest(new { Message = "Некоторые данные неккоректны", Values = Json(await _servicesManager.tables.GetList()) });

            table = new EditTables()
            {
                ID = id,
                number = number,
                capacity = capacity
            };

            await _servicesManager.tables.SaveEdit(table);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.tables.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTables(int id)
        {
            if (id > 0)
            {
                var table = await _servicesManager.tables.GetEditById(id);
                if (table == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.tables.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Visitors
        [HttpGet]
        public async Task<IActionResult> ViewVisitors()
        {
            return Json(await _servicesManager.visitors.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewVisitorsById(int id)
        {
            if (id > 0)
            {
                var visitor = await _servicesManager.visitors.GetEditById(id);
                if (visitor == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.visitors.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddVisitors(string name, string surname, string phoneNumber, string emailAddress, DateOnly dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(emailAddress) || dateOfBirth == new DateOnly(1,1,1))
                return BadRequest("Не все обязательные поля заполнены");

            await _servicesManager.visitors.SaveEdit(
                   new EditVisitors()
                   {
                       name = name,
                       surname = surname,
                       phoneNumber = phoneNumber,
                       emailAddress = emailAddress,
                       dateOfBirth = dateOfBirth
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditVisitors(int id, string name, string surname, string phoneNumber, string emailAddress, DateOnly dateOfBirth)
        {
            var visitor = await _servicesManager.visitors.GetEditById(id);
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(emailAddress) || dateOfBirth == new DateOnly(1, 1, 1))
                return BadRequest(new { Message = "Не все обязательные поля заполнены", Values = Json(await _servicesManager.visitors.GetList()) });

            visitor = new EditVisitors()
            {
                ID = id,
                name = name,
                surname = surname,
                phoneNumber = phoneNumber,
                emailAddress = emailAddress,
                dateOfBirth = dateOfBirth
            };

            await _servicesManager.visitors.SaveEdit(visitor);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.visitors.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVisitors(int id)
        {
            if (id > 0)
            {
                var visitor = await _servicesManager.visitors.GetEditById(id);
                if (visitor == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.visitors.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Accounts
        [HttpGet]
        public async Task<IActionResult> ViewAccounts()
        {
            return Json(await _servicesManager.accounts.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewAccountsById(int id)
        {
            if (id > 0)
            {
                var account = await _servicesManager.accounts.GetEditById(id);
                if (account == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.accounts.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddAccounts(int visitorID, string login, string password, DateOnly registrationDate)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || registrationDate == new DateOnly(1,1,1))
                return BadRequest("Не все обязательные поля заполнены");

            if (visitorID <= 0 || password.Length < 10)
                return BadRequest("Некоторые данные неккоректны");

            var visitor = await _servicesManager.visitors.GetEditById(visitorID);
            if (visitor == null)
                return UnprocessableEntity("Неправильный вторичный ключ");

            Accounts user = new Accounts()
            {
                visitorID = visitor.ID,
                UserName = login,
                password = password,
                registrationDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            };

            var result = await _userManager.CreateAsync(user, password);


            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Visitor"));
                return Ok("Данные успешно добавлены");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> EditAccounts(int id, int visitorID, string login, string password, DateOnly registrationDate)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || registrationDate == new DateOnly(1, 1, 1))
                return BadRequest(new { Message = "Не все обязательные поля заполнены", Values = Json(await _servicesManager.accounts.GetList()) });

            if (visitorID <= 0 || password.Length < 10)
                return BadRequest(new { Message = "Некоторые данные неккоректны", Values = Json(await _servicesManager.accounts.GetList()) });

            var visitor = await _servicesManager.visitors.GetEditById(visitorID);
            if (visitor == null)
                return UnprocessableEntity(new { Message = "Неправильный вторичный ключ", Values = Json(await _servicesManager.accounts.GetList()) });

            var user = await _userManager.FindByIdAsync(Convert.ToString(id));

            if (user == null)
                return NotFound();

            var result = await _userManager.ChangePasswordAsync(user, user.password, password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.SetUserNameAsync(user, login);


            await _servicesManager.accounts.SaveEdit(new EditAccounts()
            {
                ID = id,
                visitorID = visitorID,
                password = password,
                registrationDate = registrationDate,
                login = login,
            });

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.accounts.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccounts(int id)
        {
            var user = await _userManager.FindByIdAsync(Convert.ToString(id));
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return Ok("Данные упешно удалены");
                else
                    return BadRequest("Неправильный ID");
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Reservations
        [HttpGet]
        public async Task<IActionResult> ViewReservations()
        {
            return Json(await _servicesManager.reservations.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewReservationsById(int id)
        {
            if (id > 0)
            {
                var reservation = await _servicesManager.reservations.GetEditById(id);
                if (reservation == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.reservations.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddReservations(int visitorID, DateOnly date, TimeOnly time)
        {
            if (date == new DateOnly(1,1,1) || time == new TimeOnly(0,0))
                return BadRequest("Не все обязательные поля заполнены");

            if (visitorID <= 0)
                return BadRequest("Некоторые данные неккоректны");

            var visitor = await _servicesManager.visitors.GetEditById(visitorID);
            if (visitor == null)
                return UnprocessableEntity("Неправильный вторичный ключ");

            await _servicesManager.reservations.SaveEdit(
                   new EditReservations()
                   {
                       visitorID = visitorID,
                       date = date,
                       time = time
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditReservations(int id, int visitorID, DateOnly date, TimeOnly time)
        {
            var reservation = await _servicesManager.reservations.GetEditById(id);

            if (date == new DateOnly(1, 1, 1) || time == new TimeOnly(0, 0))
                return BadRequest(new { Message = "Не все обязательные поля заполнены", Values = Json(await _servicesManager.reservations.GetList()) });

            if (visitorID <= 0)
                return BadRequest(new { Message = "Некоторые данные неккоректны", Values = Json(await _servicesManager.reservations.GetList()) });

            var visitor = await _servicesManager.visitors.GetEditById(visitorID);
            if (visitor == null)
                return UnprocessableEntity(new { Message = "Неправильный вторичный ключ", Values = Json(await _servicesManager.reservations.GetList()) });

            reservation = new EditReservations()
            {
                ID = id,
                visitorID = visitorID,
                date = date,
                time = time
            };

            await _servicesManager.reservations.SaveEdit(reservation);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.reservations.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReservations(int id)
        {
            if (id > 0)
            {
                var reservation = await _servicesManager.reservations.GetEditById(id);
                if (reservation == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.reservations.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion


        
        #region ReservationCats
       [HttpGet]
        public async Task<IActionResult> ViewReservationCats()
        {
            return Json(await _servicesManager.reservationCats.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewReservationCatsById(int id)
        {
            if (id > 0)
            {
                var reservationCat = await _servicesManager.reservationCats.GetEditById(id);
                if (reservationCat == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.reservationCats.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddReservationCats(int reservationID, int catID)
        {
            var reservation = await _servicesManager.reservations.GetEditById(reservationID);
            var cat = await _servicesManager.cats.GetEditById(catID);
            if (reservation == null || cat == null)
                return UnprocessableEntity("Неправильный вторичный ключ");

            await _servicesManager.reservationCats.SaveEdit(
                   new EditReservationCats()
                   {
                       reservationID = reservationID,
                       catID = catID
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditReservationCats(int id, int reservationID, int catID)
        {
            var reservationCat = await _servicesManager.reservationCats.GetEditById(id);

            var reservation = await _servicesManager.reservations.GetEditById(reservationID);
            var cat = await _servicesManager.cats.GetEditById(catID);
            if (reservation == null || cat == null)
                return UnprocessableEntity(new { Message = "Неправильный вторичный ключ", Values = Json(await _servicesManager.reservationCats.GetList()) });

            reservationCat = new EditReservationCats()
            {
                ID = id,
                reservationID = reservationID,
                catID = catID
            };

            await _servicesManager.reservationCats.SaveEdit(reservationCat);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.reservationCats.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReservationCats(int id)
        {
            if (id > 0)
            {
                var reservationCat = await _servicesManager.reservationCats.GetEditById(id);
                if (reservationCat == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.reservationCats.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region ReservationTables
        [HttpGet]
        public async Task<IActionResult> ViewReservationTables()
        {
            return Json(await _servicesManager.reservationTables.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewReservationTablesById(int id)
        {
            if (id > 0)
            {
                var reservationTable = await _servicesManager.reservationTables.GetEditById(id);
                if (reservationTable == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.reservationTables.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddReservationTables(int reservationID, int tableID)
        {
            var reservation = await _servicesManager.reservations.GetEditById(reservationID);
            var table = await _servicesManager.tables.GetEditById(tableID);
            if (reservation == null || table == null)
                return UnprocessableEntity("Неправильный вторичный ключ");

            await _servicesManager.reservationTables.SaveEdit(
                   new EditReservationTables()
                   {
                       reservationID = reservationID,
                       tableID = tableID
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditReservationTables(int id, int reservationID, int tableID)
        {
            var reservationTable = await _servicesManager.reservationTables.GetEditById(id);

            var reservation = await _servicesManager.reservations.GetEditById(reservationID);
            var table = await _servicesManager.tables.GetEditById(tableID);
            if (reservation == null || table == null)
                return UnprocessableEntity(new { Message = "Неправильный вторичный ключ", Values = Json(await _servicesManager.reservationTables.GetList()) });

            reservationTable = new EditReservationTables()
            {
                ID = id,
                reservationID = reservationID,
                tableID = tableID
            };

            await _servicesManager.reservationTables.SaveEdit(reservationTable);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.reservationTables.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReservationTables(int id)
        {
            if (id > 0)
            {
                var reservationTable = await _servicesManager.reservationTables.GetEditById(id);
                if (reservationTable == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.reservationTables.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Orders
        [HttpGet]
        public async Task<IActionResult> ViewOrders()
        {
            return Json(await _servicesManager.orders.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewOrdersById(int id)
        {
            if (id > 0)
            {
                var order = await _servicesManager.orders.GetEditById(id);
                if (order == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.orders.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddOrders(int visitorID, int tableID, DateOnly date, TimeOnly time)
        {
            if (date == new DateOnly(1, 1, 1) || time == new TimeOnly(0, 0))
                return BadRequest("Не все обязательные поля заполнены");

            if (visitorID <= 0 || tableID <= 0)
                return BadRequest("Некоторые данные неккоректны");

            var visitor = await _servicesManager.visitors.GetEditById(visitorID);
            var table = await _servicesManager.tables.GetEditById(tableID);
            if (visitor == null || table == null)
                return UnprocessableEntity("Неправильный вторичный ключ");

            await _servicesManager.orders.SaveEdit(
                   new EditOrders()
                   {
                       visitorID = visitorID,
                       tableID = tableID,
                       date = date,
                       time = time
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditOrders(int id, int visitorID, int tableID, DateOnly date, TimeOnly time)
        {
            var order = await _servicesManager.orders.GetEditById(id);

            if (date == new DateOnly(1, 1, 1) || time == new TimeOnly(0, 0))
                return BadRequest(new { Message = "Не все обязательные поля заполнены", Values = Json(await _servicesManager.orders.GetList()) });

            if (visitorID <= 0)
                return BadRequest(new { Message = "Некоторые данные неккоректны", Values = Json(await _servicesManager.orders.GetList()) });

            var visitor = await _servicesManager.visitors.GetEditById(visitorID);
            var table = await _servicesManager.tables.GetEditById(tableID);
            if (visitor == null || table == null)
                return UnprocessableEntity(new { Message = "Неправильный вторичный ключ", Values = Json(await _servicesManager.orders.GetList()) });

            order = new EditOrders()
            {
                ID = id,
                visitorID = visitorID,
                tableID = tableID,
                date = date,
                time = time
            };

            await _servicesManager.orders.SaveEdit(order);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.orders.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            if (id > 0)
            {
                var order = await _servicesManager.orders.GetEditById(id);
                if (order == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.orders.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Contents
        [HttpGet]
        public async Task<IActionResult> ViewContents()
        {
            return Json(await _servicesManager.contents.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewContentsById(int id)
        {
            if (id > 0)
            {
                var content = await _servicesManager.contents.GetEditById(id);
                if (content == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.contents.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddContents(int orderID, int productID, int quantity)
        {
            if (quantity <= 0)
                return BadRequest("Некоторые данные неккоректны");

            var order = await _servicesManager.orders.GetEditById(orderID);
            var product = await _servicesManager.products.GetEditById(productID);
            if (order == null || product == null)
                return UnprocessableEntity("Неправильный вторичный ключ");

            await _servicesManager.contents.SaveEdit(
                   new EditContents()
                   {
                       orderID = orderID,
                       productID = productID,
                       quantity = quantity
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditContents(int id, int orderID, int productID, int quantity)
        {
            var content = await _servicesManager.contents.GetEditById(id);

            if (quantity <= 0)
                return BadRequest(new { Message = "Некоторые данные неккоректны", Values = Json(await _servicesManager.contents.GetList()) });

            var order = await _servicesManager.orders.GetEditById(orderID);
            var product = await _servicesManager.products.GetEditById(productID);
            if (order == null || product == null)
                return UnprocessableEntity(new { Message = "Неправильный вторичный ключ", Values = Json(await _servicesManager.contents.GetList()) });

            content = new EditContents()
            {
                ID = id,
                orderID = orderID,
                productID = productID,
                quantity = quantity
            };

            await _servicesManager.contents.SaveEdit(content);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.contents.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContents(int id)
        {
            if (id > 0)
            {
                var content = await _servicesManager.contents.GetEditById(id);
                if (content == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.contents.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



        #region Reviews
        [HttpGet]
        public async Task<IActionResult> ViewReviews()
        {
            return Json(await _servicesManager.reviews.GetList());
        }

        [HttpPut]
        public async Task<IActionResult> ViewReviewsById(int id)
        {
            if (id > 0)
            {
                var review = await _servicesManager.reviews.GetEditById(id);
                if (review == null)
                    return UnprocessableEntity("Объект не найден");
                else
                    return Ok(new { Message = "Найден", Values = Json(await _servicesManager.reviews.GetList()) });
            }
            return BadRequest("Неправильный ID");
        }

        [HttpPost]
        public async Task<IActionResult> AddReviews(int visitorID, string text, DateOnly date, TimeOnly time, int rating)
        {
            if (string.IsNullOrWhiteSpace(text) || date == new DateOnly(1, 1, 1) || time == new TimeOnly(0, 0))
                return BadRequest("Не все обязательные поля заполнены");

            if (visitorID <= 0 || (rating <= 0 && rating > 5))
                return BadRequest("Некоторые данные неккоректны");

            var visitor = await _servicesManager.visitors.GetEditById(visitorID);
            if (visitor == null)
                return UnprocessableEntity("Неправильный вторичный ключ");

            await _servicesManager.reviews.SaveEdit(
                   new EditReviews()
                   {
                       visitorID = visitorID,
                       text = text,
                       date = date,
                       time = time,
                       rating = rating
                   });

            return Ok("Данные успешно добавлены");
        }

        [HttpPut]
        public async Task<IActionResult> EditReviews(int id, int visitorID, string text, DateOnly date, TimeOnly time, int rating)
        {
            var review = await _servicesManager.reviews.GetEditById(id);

            if (string.IsNullOrWhiteSpace(text) || date == new DateOnly(1, 1, 1) || time == new TimeOnly(0, 0))
                return BadRequest(new { Message = "Не все обязательные поля заполнены", Values = Json(await _servicesManager.reviews.GetList()) });

            if (visitorID <= 0 || (rating <= 0 && rating > 5))
                return BadRequest(new { Message = "Некоторые данные неккоректны", Values = Json(await _servicesManager.reviews.GetList()) });

            var visitor = await _servicesManager.visitors.GetEditById(visitorID);
            if (visitor == null)
                return UnprocessableEntity(new { Message = "Неправильный вторичный ключ", Values = Json(await _servicesManager.reviews.GetList()) });

            review = new EditReviews()
            {
                ID = id,
                visitorID = visitorID,
                text = text,
                date = date,
                time = time,
                rating = rating
            };

            await _servicesManager.reviews.SaveEdit(review);

            return Ok(new { Message = "Изменения успешно внесены", Values = Json(await _servicesManager.reviews.GetList()) });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReviews(int id)
        {
            if (id > 0)
            {
                var review = await _servicesManager.reviews.GetEditById(id);
                if (review == null)
                    return UnprocessableEntity("Объект не найден");
                else
                {
                    await _servicesManager.reviews.DeleteView(id);
                    return Ok("Данные упешно удалены");
                }
            }
            return BadRequest("Неправильный ID");
        }
        #endregion



    }
}