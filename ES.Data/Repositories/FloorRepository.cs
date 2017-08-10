using System;
using System.Collections.Generic;
using ES.Data.Models;
using ES.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace ES.Data.Repositories
{
    public class FloorRepository : Repository<BuildingFloor>, IFloorRepository
    {
        public FloorRepository(DbContext context) : base(context)
        { }

        private ApplicationDbContext appContext
        {
            get { return (ApplicationDbContext)_context; }
        }

        public async Task<List<BuildingFloor>> GetFloorChildIncuded()
        {
           return await appContext.BuildingFloor.Include(x => x.buildingEntrance).ToListAsync();
        }

        public async Task<List<BuildingFloor>> GetFloorByEntranceIncluded(int id)
        {
            return (await GetFloorChildIncuded()).Where(x => x.buildingEntrance.id == id).ToList();
        }
    }
}
