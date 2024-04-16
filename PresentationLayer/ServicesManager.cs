using BusinessLayer;
using PresentationLayer.Services;

namespace PresentationLayer
{
    public class ServicesManager
    {
        DataManager _dataManager;

        private readonly VisitorsService _visitorsService;
        private readonly AccountsService _accountsService;

        private readonly CatsService _catsService;
        private readonly BreedsService _breedsService;

        private readonly ReservationsService _reservationsService;
        private readonly ReservationCatsService _reservationCatsService;
        private readonly ReservationTablesService _reservationTablesService;

        private readonly EmployeesService _employeesService;
        private readonly PositionsService _positionsService;

        private readonly ProductsService _productsService;
        private readonly ProductTypesService _productTypesService;

        private readonly OrdersService _ordersService;
        private readonly ContentsService _contentsService;

        private readonly ReviewsService _reviewsService;

        private readonly TablesService _tablesService;

        private readonly EventsService _eventsService;

        public ServicesManager(
            DataManager dataManager
            )
        {
            _dataManager = dataManager;

            _visitorsService = new VisitorsService(_dataManager);
            _accountsService = new AccountsService(_dataManager);

            _catsService = new CatsService(_dataManager);
            _breedsService = new BreedsService(_dataManager);

            _reservationsService = new ReservationsService(_dataManager);
            _reservationCatsService = new ReservationCatsService(_dataManager);
            _reservationTablesService = new ReservationTablesService(_dataManager);

            _employeesService = new EmployeesService(_dataManager);
            _positionsService = new PositionsService(_dataManager);

            _productsService = new ProductsService(_dataManager);
            _productTypesService = new ProductTypesService(_dataManager);

            _ordersService = new OrdersService(_dataManager);
            _contentsService = new ContentsService(_dataManager);

            _reviewsService = new ReviewsService(_dataManager);

            _tablesService = new TablesService(_dataManager);

            _eventsService = new EventsService(_dataManager);
        }

        public VisitorsService visitors { get {  return _visitorsService; } }
        public AccountsService accounts { get { return _accountsService; } }

        public CatsService cats { get { return _catsService; } }
        public BreedsService breeds { get { return _breedsService; } }

        public ReservationsService reservations { get {  return _reservationsService; } }
        public ReservationCatsService reservationCats {  get { return _reservationCatsService; } }
        public ReservationTablesService reservationTables { get { return _reservationTablesService; } }

        public EmployeesService employees { get {  return _employeesService; } }
        public PositionsService positions { get { return _positionsService; } }

        public ProductsService products { get { return _productsService; } }
        public ProductTypesService productTypes { get { return _productTypesService; } }

        public OrdersService orders { get { return _ordersService; } }
        public ContentsService contents { get { return _contentsService; } }

        public ReviewsService reviews {  get { return _reviewsService; } }

        public TablesService tables { get { return _tablesService; } }

        public EventsService events { get { return _eventsService; } }
    }
}
