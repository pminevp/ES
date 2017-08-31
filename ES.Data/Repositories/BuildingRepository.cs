using ES.Data.Models;
using ES.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ES.Data.Repositories
{
    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(DbContext context) : base(context)
        {

        }

        public async Task<Building> GetBuildingByName(string buildingName)
        {
            return await appContext.Building.FirstOrDefaultAsync(x => x.Name == buildingName);
        }
        
        private ApplicationDbContext appContext
        {
            get { return (ApplicationDbContext)_context; }
        }   
    }
}