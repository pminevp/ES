using ES.Data.Models;
using System.Collections.Generic;

namespace ES.Data.Repositories.Interfaces
{
   public interface IBuildingEntranceRepository : Repository<BuildingEntrance>
    {
        List<BuildingEntrance> GetByBuildingId(int id);
        List<BuildingEntrance> GetByUserId(int buildingId, string userId);
    }
}
