using ES.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ES.Data.Repositories.Interfaces
{
    public interface IApartamentRepository : Repository<Apartament>
    {
        Task<List<Apartament>> GetApartamentsByFloorId(int id);

        Task<Apartament> GetApartamentOwnerIncluded(int id);

        Task<List<Apartament>> GetApartamentsByBuilding(int buildingId);

        Task<List<Apartament>> GetApartamentsByBuildingName(string buildingName);

        Apartament CreateDefaultApartament();
    }
}
