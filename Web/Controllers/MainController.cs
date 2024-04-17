using BusinessLayer;
using PresentationLayer;
using PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Entities;

namespace Web.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;
        private MainPageModel main = new MainPageModel();
        private UserManager<Accounts> _userManager;
        private SignInManager<Accounts> _signInManager;
        private readonly BasketModel _basket;

        public MainController(DataManager dataManager, UserManager<Accounts> userManager, SignInManager<Accounts> signInManager, BasketModel basket)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
            _userManager = userManager;
            _signInManager = signInManager;
            _basket = basket;
        }



        #region Page

        [HttpGet]
        public async Task<IActionResult> Main()
        {
            ICollection<ViewEvents> events = await NewEvents();
            ICollection<ViewProducts> popularProducts = await PopularPizzas();

            main.Events = events;
            main.PopularProducts = popularProducts;

            return View(main);
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Workers()
        {
            return View(await _servicesManager.employees.GetList());
        }

        [HttpGet]
        public async Task<IActionResult> Reviews()
        {
            return View(await _servicesManager.reviews.GetList());
        }

        [HttpGet][Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        #endregion



        #region Main

        [HttpPut]
        public async Task<IActionResult> FilteredProducts(bool cheap = false, bool expensive = false, int min = 0, int max = 100, string search = "")
        {
            ICollection<ViewProducts> products = await _servicesManager.products.GetList();

            products = products.Where(p => p.price >= min && p.price <= max).ToList();

            if (search != "")
                products = products.Where(p => (p.name).ToLower().Contains(search)).ToList();

            if (cheap)
                products = products.OrderBy(p => p.price).ToList();
            else if (expensive)
                products = products.OrderByDescending(p => p.price).ToList();

            products = await SortingProducts(products);

            return Json(products);
        }

        public async Task<ICollection<ViewProducts>> SortingProducts(ICollection<ViewProducts> products)
        {
            var pizzas = products.Where(p => p.type.name == "Пицца").ToList();
            var otherProducts = products.Except(pizzas).ToList();

            pizzas.Sort((p1, p2) => string.Compare(p1.type.name, p2.type.name));

            return pizzas.Concat(otherProducts).ToList();

        }

        public async Task<ICollection<ViewProducts>> PopularPizzas()
        {
            var popularPizzaIDs = (await _servicesManager.orders
                .GetList())
                .SelectMany(order => order.contents)
                .Where(content => content.product.type.name == "Пицца")
                .GroupBy(content => new { content.orderID, content.product.ID })
                .Select(group => group.First())
                .GroupBy(content => content.product.ID)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key).Take(10).ToList();

            ICollection<ViewProducts> pizzas = new List<ViewProducts>();

            foreach (int ID in popularPizzaIDs)
                pizzas.Add(await _servicesManager.products.GetViewById(ID));

            return pizzas.ToList();
        }

        public async Task<ICollection<ViewEvents>> NewEvents()
        {
            DateTime startDate = DateTime.Today.AddDays(-10);

            DateOnly date = new DateOnly(startDate.Year, startDate.Month, startDate.Day); ;

            ICollection<ViewEvents> events = await _servicesManager.events.GetList();

            var recentEvents = events.Where(e => e.date >= date);

            var sortedEvents = recentEvents.OrderByDescending(e => e.date);

            return sortedEvents.ToList();
        }

        #endregion



        #region Visitor

        [HttpPost]
        public async Task<IActionResult> AddReview(string text, int rating)
        {

            if (string.IsNullOrWhiteSpace(text))
                return BadRequest("Не все обязательные поля заполнены");

            if ((rating <= 0 || rating > 5))
                return BadRequest("Некоторые данные неккоректны");

            DateTime currentDateTime = DateTime.Now;
            DateOnly date = new DateOnly(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day);
            TimeOnly time = new TimeOnly(currentDateTime.Hour, currentDateTime.Minute);



            await _servicesManager.reviews.SaveEdit(
                   new EditReviews()
                   {
                       visitorID = GetVisitorID(),
                       text = text,
                       date = date,
                       time = time,
                       rating = rating
                   });

            return Ok("Отзыв оставлен");
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(int month, int day, TimeOnly time, string tables, string cats = "")
        {
            DateOnly date = new DateOnly(DateTime.Now.Year, month, day);
            int[] tableIDs = tables.Split(',').Select(int.Parse).ToArray();
            int[] catIDs = new int[0];

            if (cats != "")
                catIDs = cats.Split(',').Select(int.Parse).ToArray();

            ViewReservations reservation = await _servicesManager.reservations.SaveEdit(
                   new EditReservations()
                   {
                       visitorID = GetVisitorID(),
                       date = date,
                       time = time
                   });

            foreach(int id in tableIDs)
            {
                await _servicesManager.reservationTables.SaveEdit(
                   new EditReservationTables()
                   {
                       reservationID = reservation.ID,
                       tableID = id,
                   });
            }

            foreach (int id in catIDs)
            {
                await _servicesManager.reservationCats.SaveEdit(
                    new EditReservationCats()
                    {
                        reservationID = reservation.ID,
                        catID = id,
                    });
            }


            return Ok("Отзыв оставлен");
        }

        [HttpGet]
        public async Task<IActionResult> VisitorOrders()
        {
            ICollection<ViewOrders> orders = (await _servicesManager.orders
                .GetList())
                .Where(o => o.visitorID == GetVisitorID())
                .ToList();

            return Json(orders);
        }

        public int GetVisitorID()
        {
            int _visitorID = 0;
            var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            if (user != null)
            {
                _visitorID = user.visitorID;
            }
            return _visitorID;
        }
        
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/login");
        }

        #endregion



        #region Reservation

        [HttpPut]
        public async Task<IActionResult> CheckTables(int month, int day, TimeOnly time)
        {
            ICollection<ViewReservations> reservations = await _servicesManager.reservations.GetList();
            ICollection<ViewOrders> orders = await _servicesManager.orders.GetList();

            ICollection<ViewTables> tables = await _servicesManager.tables.GetList();

            List<CheckedTables> checkedTables = new List<CheckedTables>();

            DateOnly date = new DateOnly(DateTime.Now.Year, month, day);

            foreach (var table in tables)
            {
                bool isOccupied = false;

                foreach (var reservation in reservations)
                {
                    if (reservation.tables != null)
                    {
                        foreach (var table1 in reservation.tables)
                        {
                            if (table1.ID == table.ID && reservation.date == date && reservation.time == time)
                            {
                                isOccupied = true;
                                break;
                            }
                        }
                    }
                }

                if (!isOccupied)
                {
                    foreach (var order in orders)
                    {
                        if (order.table != null && order.table.ID == table.ID && order.date == date && order.time == time)
                        {
                            isOccupied = true;
                            break;
                        }
                    }
                }

                checkedTables.Add(new CheckedTables
                {
                    ID = table.ID,
                    number = table.number,
                    capacity = table.capacity,
                    availability = !isOccupied
                });
            }

            return Ok(checkedTables);
        }

        [HttpPut]
        public async Task<IActionResult> CheckCats(int month, int day, TimeOnly time)
        {
            ICollection<ViewReservations> reservations = await _servicesManager.reservations.GetList();
            ICollection<ViewCats> cats = await _servicesManager.cats.GetList();
            List<ViewCats> availableCats = new List<ViewCats>();

            DateOnly date = new DateOnly(DateTime.Now.Year, month, day);

            foreach (var cat in cats)
            {
                bool isOccupied = false;

                foreach (var reservation in reservations)
                {
                    if (reservation.cats != null && reservation.cats.Any(c => c.ID == cat.ID && reservation.date == date && reservation.time == time))
                    {
                        isOccupied = true;
                        break;
                    }
                }

                if (!isOccupied)
                {
                    availableCats.Add(cat);
                }
            }

            return Ok(availableCats);
        }

        #endregion



        #region Basket

        [HttpPut]
        public IActionResult AddToBasket(int id, int action = 0)
        {
            ViewProducts product = _servicesManager.products.GetViewById(id).GetAwaiter().GetResult();

            if (product != null)
            {
                var cart = _basket.Get(Convert.ToString(GetVisitorID()));

                if (cart.ContainsKey(id))
                    cart[id] += action;
                else
                    cart.Add(id, 1);

                if(cart[id] <= 0)
                    cart.Remove(id);

                _basket.Update(Convert.ToString(GetVisitorID()), cart);
                return Ok($"{product.name} добавлено в корзину");
            }
            return BadRequest("Продукт не найден");
        }
        
        [HttpPut]
        public IActionResult RepeatOrderToBasket(List<int> productIDs)
        {
            if (productIDs.Count <= 0)
                return BadRequest("Упс! Продуктов нет");

            var cart = _basket.Get(Convert.ToString(GetVisitorID()));

            foreach (int id in productIDs)
            {
                ViewProducts product = _servicesManager.products.GetViewById(id).GetAwaiter().GetResult();

                if (product != null)
                {
                    if (cart.ContainsKey(id))
                        cart[id] += 1;
                    else
                        cart.Add(id, 1);

                    if (cart[id] <= 0)
                        cart.Remove(id);
                }
                else
                    return BadRequest("Какой-то из продуктов не найден");
            }

            _basket.Update(Convert.ToString(GetVisitorID()), cart);
            return Ok();
        }

        [HttpPut]
        public IActionResult RemoveFromBasket(int id)
        {
            var cart = _basket.Get(Convert.ToString(GetVisitorID()));

            if (cart.ContainsKey(id))
            {
                cart.Remove(id);
                _basket.Update(Convert.ToString(GetVisitorID()), cart);
            }
            else
                return BadRequest("Продукта больше нет в корзине");

            return Ok();
        }

        [HttpGet]
        public IActionResult ClearBasket()
        {
            var cart = new Dictionary<int, int>();
            _basket.Update(Convert.ToString(GetVisitorID()), cart);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ViewBasket()
        {
            var cart = _basket.Get(Convert.ToString(GetVisitorID()));

            List<KeyValuePair<ViewProducts, int>> products = new List<KeyValuePair<ViewProducts, int>>();

            foreach (var product in cart)
            {
                var viewProduct = await _servicesManager.products.GetViewById(product.Key);
                products.Add(new KeyValuePair<ViewProducts, int>(viewProduct, product.Value));
            }

            return Json(products);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmOrder()
        {
            var cart = _basket.Get(Convert.ToString(GetVisitorID()));
            
            if (cart == null)
                return BadRequest("Корзина пуста");
            
            ViewOrders order = await _servicesManager.orders.SaveEdit(new EditOrders()
            {
                tableID = null,
                visitorID = GetVisitorID(),
                date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                time = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute)
            });


            foreach(var product in cart)
            {
                await _servicesManager.contents.SaveEdit(new EditContents()
                {
                    orderID = order.ID,
                    productID = product.Key,
                    quantity = product.Value
                });
            }

            ClearBasket();
            return Ok();
        }

        #endregion



    }
}
