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

        public Task<Building> GetBuildingByOwner(string ownerId)
        {
            var owner = appContext.Users.FirstOrDefaultAsync(x => x.Id == ownerId).Result;
            return appContext.Building.FirstOrDefaultAsync(x => x.Id == owner.BuildingId);
        }

        private ApplicationDbContext appContext
        {
            get { return (ApplicationDbContext)_context; }
        }   
    }
}