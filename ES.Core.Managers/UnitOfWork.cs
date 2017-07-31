using ES.Data;
using ES.Data.Repositories;
using ES.Data.Repositories.Interfaces;

namespace ES.Core.Handlers
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        ICustomerRepository _customers;
        IProductRepository _products;
        IOrdersRepository _orders;
        IFloorRepository _floor;
        IApartamentRepository _apartament;
        IBuildingRepository _building;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }



        public ICustomerRepository Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new CustomerRepository(_context);

                return _customers;
            }
        }



        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                    _products = new ProductRepository(_context);

                return _products;
            }
        }



        public IOrdersRepository Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new OrdersRepository(_context);

                return _orders;
            }
        }

        public IFloorRepository BuildingFloor
        {
            get
            {
                if (_floor == null)
                    _floor = new FloorRepository(_context);

                return _floor;
            }
        }

        public IApartamentRepository Apartaments
        {
            get
            {
                if (_apartament == null)
                    _apartament = new ApartamentRepository(_context);

                return _apartament;
            }
        }

        public IBuildingRepository Buildings
        {
            get
            {
                if (_building == null)
                    _building = new BuildingRepository(_context);

                return _building;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
