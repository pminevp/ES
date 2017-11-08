using ES.Data.Models;
using ES.Data.Repositories.Interfaces;
using System.Collections.Generic;

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

        INotificationRepository Notifications { get;  }

        List<BuildingFloor> GetBuildingFloorByEntranceId(int id);

        IDocumentFileRepository Documentfiles { get; }

        IDocumentDataTypeRepository DocumentDataType { get; }

        int SaveChanges();
    }
}
