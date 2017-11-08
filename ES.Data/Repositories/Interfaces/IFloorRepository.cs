using ES.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ES.Data.Repositories.Interfaces
{
    public interface IFloorRepository : Repository<BuildingFloor>
    {
        Task<List<BuildingFloor>> GetFloorChildIncuded();

        Task<List<BuildingFloor>> GetFloorByEntranceIncluded(int id);

        Task<BuildingFloor> GetFloorWithEntrenceIncluded(int id);

        BuildingFloor GetFloorByEntranceId(int buildingEntranceId);
    }
}
