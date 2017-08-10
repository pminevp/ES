using ES.Data.Models;
using System.Collections.Generic;

namespace ES.Data.Repositories.Interfaces
{
   public interface IBuildingEntranceRepository : IRepository<BuildingEntrance>
    {
        List<BuildingEntrance> GetByBuildingId(int id);
    }
}
