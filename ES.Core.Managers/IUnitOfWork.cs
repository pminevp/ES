﻿using ES.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Core.Handlers
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        IOrdersRepository Orders { get; }


        IFloorRepository BuildingFloor { get; }

        IApartamentRepository Apartaments { get; }

        IBuildingRepository Buildings { get; }

        IBuildingEntranceRepository BuildingEntrance { get; }

        int SaveChanges();
    }
}
