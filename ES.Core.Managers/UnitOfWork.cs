﻿using System;
using System.Collections.Generic;
using ES.Data;
using ES.Data.Models;
using ES.Data.Repositories;
using ES.Data.Repositories.Interfaces;
using System.Linq;

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
        IBuildingEntranceRepository _buildingEntrance;
        INotificationRepository _notifications;
        IDocumentFileRepository _documentfiles;
        IDocumentDataTypeRepository _documentDataType;

        public UnitOfWork(ApplicationDbContext context)
        {       
            _context = context;
        }


        public IDocumentDataTypeRepository DocumentDataType
        {
            get
            {
                if (_documentDataType == null)
                    _documentDataType = new DocumentDataTypeRepository(_context);

                return _documentDataType;
            }
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

        public IBuildingEntranceRepository BuildingEntrance
        {
            get
            {
                if (_buildingEntrance == null)
                    _buildingEntrance = new BuildingEntranceRepository(_context);

                return _buildingEntrance;
            }
        }

        public INotificationRepository Notifications
        {
            get
            {
                if (_notifications == null)
                    _notifications = new NotificationRepository(_context);

                return _notifications;
            }
        }

        public List<BuildingFloor> GetBuildingFloorByEntranceId(int id)
        {
            var floors = BuildingFloor.GetAll();

            return floors.Where(x => x.buildingEntrance.id == id).ToList();
        }

        public IDocumentFileRepository Documentfiles
        {
            get
            {
                if (_documentfiles == null)
                    _documentfiles = new DocumentFileRepository(_context);

                return _documentfiles;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
