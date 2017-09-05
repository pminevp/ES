using ES.Data.Models;
using System.Threading.Tasks;

namespace ES.Data.Repositories.Interfaces
{
    public interface IBuildingRepository : IRepository<Building>
    {
        Task<Building> GetBuildingByName(string buildingName);
        Task<Building> GetBuildingByOwner(string ownerId);
    }
}
