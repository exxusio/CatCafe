using BusinessLayer.Interfaces;

namespace BusinessLayer
{
    public class DataManager
    {
        private readonly IVisitorsRepository _visitorsRepository;
        private readonly IAccountsRepository _accountsRepository;

        private readonly ICatsRepository _catsRepository;
        private readonly IBreedsRepository _breedsRepository;

        private readonly IReservationsRepository _reservationsRepository;
        private readonly IReservationCatsRepository _reservationCatsRepository;
        private readonly IReservationTablesRepository _reservationTablesRepository;

        private readonly IEmployeesRepository _employeesRepository;
        private readonly IPositionsRepository _positionsRepository;

        private readonly IProductsRepository _productsRepository;
        private readonly IProductTypesRepository _productTypesRepository;

        private readonly IOrdersRepository _ordersRepository;
        private readonly IContentsRepository _contentsRepository;

        private readonly IReviewsRepository _reviewsRepository;

        private readonly ITablesRepository _tablesRepository;

        private readonly IEventsRepository _eventsRepository;

        public DataManager(IVisitorsRepository visitorsRepository, IAccountsRepository accountsRepository, ICatsRepository catsRepository, IBreedsRepository breedsRepository, IReservationsRepository reservationsRepository, IReservationCatsRepository reservationCatsRepository, IReservationTablesRepository reservationTablesRepository, IEmployeesRepository employeesRepository, IPositionsRepository positionsRepository, IProductsRepository productsRepository, IProductTypesRepository productTypesRepository, IOrdersRepository ordersRepository, IContentsRepository contentsRepository, IReviewsRepository reviewsRepository, ITablesRepository tablesRepository, IEventsRepository eventsRepository)
        {
            _visitorsRepository = visitorsRepository;
            _accountsRepository = accountsRepository;
            _catsRepository = catsRepository;
            _breedsRepository = breedsRepository;
            _reservationsRepository = reservationsRepository;
            _reservationCatsRepository = reservationCatsRepository;
            _reservationTablesRepository = reservationTablesRepository;
            _employeesRepository = employeesRepository;
            _positionsRepository = positionsRepository;
            _productsRepository = productsRepository;
            _productTypesRepository = productTypesRepository;
            _ordersRepository = ordersRepository;
            _contentsRepository = contentsRepository;
            _reviewsRepository = reviewsRepository;
            _tablesRepository = tablesRepository;
            _eventsRepository = eventsRepository;
        }

        public IVisitorsRepository visitors {  get { return _visitorsRepository; } }
        public IAccountsRepository accounts { get { return _accountsRepository; } }

        public ICatsRepository cats { get { return _catsRepository; } }
        public IBreedsRepository breeds { get { return _breedsRepository; } }

        public IReservationsRepository reservations { get { return _reservationsRepository; } }
        public IReservationCatsRepository reservationCats { get { return _reservationCatsRepository; } }
        public IReservationTablesRepository reservationTables { get { return _reservationTablesRepository; } }

        public IEmployeesRepository employees { get { return _employeesRepository; } }
        public IPositionsRepository positions { get { return _positionsRepository; } }

        public IProductsRepository products { get { return _productsRepository; } }
        public IProductTypesRepository productTypes { get { return _productTypesRepository; } }

        public IOrdersRepository orders { get { return _ordersRepository; } }
        public IContentsRepository contents { get { return _contentsRepository; } }

        public IReviewsRepository reviews { get { return _reviewsRepository; } }

        public ITablesRepository tables { get { return _tablesRepository; } }

        public IEventsRepository events { get { return _eventsRepository; } }
    }
}
