using BusinessLayer;
using PresentationLayer;
using PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    //[Authorize]
    public class MainController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;
        private MainPageModel main = new MainPageModel();

        private int _visitorID = 6;
        private Dictionary<int, int> basketItems = new Dictionary<int, int>();

        public MainController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }

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

        [HttpGet]//[Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }



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
                       visitorID = _visitorID,
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
                       visitorID = _visitorID,
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

        [HttpGet]
        public async Task<IActionResult> VisitorOrders()
        {
            ICollection<ViewOrders> orders = (await _servicesManager.orders
                .GetList())
                .Where(o => o.visitorID == _visitorID)
                .ToList();
            
            return Json(orders);
        }

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

        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(int id)
        {
            ViewProducts product = await _servicesManager.products.GetViewById(id);

            if(product != null)
            {
                if (basketItems.ContainsKey(id))
                    basketItems[id]++;
                else
                    basketItems.Add(id, 1);

                Console.WriteLine(basketItems[id] + "   ================================================================");
                return Ok();
            }

            return NotFound();
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
    }
}
