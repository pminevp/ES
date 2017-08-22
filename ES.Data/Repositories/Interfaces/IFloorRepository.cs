using ES.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ES.Data.Repositories.Interfaces
{
    public interface IFloorRepository : IRepository<BuildingFloor>
    {
        Task<List<BuildingFloor>> GetFloorChildIncuded();

        Task<List<BuildingFloor>> GetFloorByEntranceIncluded(int id);

        Task<BuildingFloor> GetFloorWithEntrenceIncluded(int id);
    }
}
